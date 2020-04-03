using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BundleVisualizer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void tsBtnFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdBundle.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofdBundle.FileName;
                ProcessBundles(fileName);
            }
        }

        private void ProcessBundles(string fileName)
        {
            string json = File.ReadAllText(fileName);
            Bundle[] bundles = JsonConvert.DeserializeObject<Bundle[]>(json);

            foreach (var bundle in bundles)
            {
                bundle.BundleInputs = ProcessBundle(bundle, fileName);

                // calculate sizes
                long totalBundleSize = bundle.TotalBundleSize;
                foreach (var bundleInput in bundle.BundleInputs)
                {
                    bundleInput.PercentOfTotal = PercentOfTotal(bundleInput.FileSize, totalBundleSize);
                }
            }

            AddToListView(bundles);
        }

        private List<BundleInput> ProcessBundle(Bundle bundle, string bundleFilePath)
        {
            List<BundleInput> inputList = new List<BundleInput>();
            string bundleDir = new FileInfo(bundleFilePath).DirectoryName;            

            foreach (var filePath in bundle.InputFiles)
            {
                var absolutePath = Path.Combine(bundleDir, filePath);

                // normalize possible wrong slashes
                var normalizedPath = Path.GetFullPath((new Uri(absolutePath)).LocalPath);
                FileInfo fi = new FileInfo(normalizedPath);

                BundleInput bundleInput = new BundleInput
                {
                    FullFilePath = normalizedPath,
                    FileSize = fi.Length
                };

                inputList.Add(bundleInput);
            }

            return inputList;
        }

        private void PrintToDebugWindow(Bundle[] bundles)
        {
            // print info
            foreach (var enrichedBundle in bundles)
            {
                long totalBundleSize = enrichedBundle.TotalBundleSize;
                Debug.Print($"{enrichedBundle.OutputFileName}. Total Size: {totalBundleSize} bytes");

                foreach (var bundleInput in enrichedBundle.BundleInputs.OrderByDescending(bi => bi.FileSize))
                {
                    string fileTitle = bundleInput.FullFilePath.PadLeft(110);
                    string fileSize = bundleInput.FileSize.ToString().PadLeft(10);
                    string percent = bundleInput.PercentOfTotal.ToString("#0.##").PadLeft(4);

                    Debug.Print("\t" + $"{fileTitle}{fileSize} bytes, {percent}%");
                }

                Debug.Print("");
                Debug.Print("");
            }
        }

        private void AddToListView(Bundle[] bundles)
        {
            lvBundles.Items.Clear();

            foreach (var enrichedBundle in bundles)
            {
                long totalBundleSize = enrichedBundle.TotalBundleSize;

                ListViewItem lviBundleTitle = new ListViewItem();
                lviBundleTitle.Text = enrichedBundle.OutputFileName;
                lviBundleTitle.SubItems.Add("");
                lviBundleTitle.SubItems.Add(totalBundleSize.ToString());

                lvBundles.Items.Add(lviBundleTitle);

                foreach (var bundleInput in enrichedBundle.BundleInputs.OrderByDescending(bi => bi.FileSize))
                {
                    string fileTitle = bundleInput.FullFilePath.PadLeft(110);
                    string fileSize = bundleInput.FileSize.ToString().PadLeft(10);
                    string percent = bundleInput.PercentOfTotal.ToString("#0.##").PadLeft(4);

                    ListViewItem lviBundleInput = new ListViewItem();
                    lviBundleInput.Text = "";
                    lviBundleInput.SubItems.Add(bundleInput.FullFilePath);
                    lviBundleInput.SubItems.Add(bundleInput.FileSize.ToString());
                    lviBundleInput.SubItems.Add(bundleInput.PercentOfTotal.ToString("#0.##"));

                    lvBundles.Items.Add(lviBundleInput);
                }

                // add space
                lvBundles.Items.Add(new ListViewItem());
            }

            lvBundles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvBundles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private double PercentOfTotal(long fraction, long totalSize)
        {
            return ((double)fraction / totalSize) * 100;
        }
    }

}
