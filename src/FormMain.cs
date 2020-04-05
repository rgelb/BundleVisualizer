using BundleVisualizer.Common;
using BundleVisualizer.Models;
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
        #region Private Variables

        private Bundle[] currentBundles = null;

        #endregion

        #region Constructors

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormMain_Load(object sender, EventArgs e) {
            InitilizeMiscUI();
        }

        private void tsBtnFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdBundle.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofdBundle.FileName;
                ProcessBundles(fileName);
            }
        }

        private void tsBtnFilter_Click(object sender, EventArgs e) {
            FilterResults();
        }

        private void tsTxtFilter_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                FilterResults();
            }
        }

        #endregion

        #region Private Methods

        private void ProcessBundles(string fileName)
        {
            try {
                if (string.IsNullOrWhiteSpace(fileName)) return;

                string json = File.ReadAllText(fileName);
                Bundle[] bundles = JsonConvert.DeserializeObject<Bundle[]>(json);

                foreach (var bundle in bundles) {
                    bundle.BundleInputs = ProcessBundle(bundle, fileName);

                    // calculate sizes
                    long totalBundleSize = bundle.TotalBundleSize;
                    foreach (var bundleInput in bundle.BundleInputs) {
                        bundleInput.PercentOfTotal = Utilities.PercentOfTotal(bundleInput.FileSize, totalBundleSize);
                    }
                }

                // cache bundles (in case user wants to filter them)
                currentBundles = bundles;

                AddToListView(bundles);
            }
            catch (Exception ex) {
                MessageBox.Show($"Error while processing bundle: {ex.Message}");
            }
        }

        private List<BundleInput> ProcessBundle(Bundle bundle, string bundleFilePath)
        {
            List<BundleInput> inputList = new List<BundleInput>();
            string bundleDir = new FileInfo(bundleFilePath).DirectoryName;

            // process output file & normalize possible wrong slashes
            var outputAbsolutePath = Path.Combine(bundleDir, bundle.OutputFileName);
            bundle.BundleOutputPath = Path.GetFullPath((new Uri(outputAbsolutePath)).LocalPath);

            // process input files
            foreach (var filePath in bundle.InputFiles)
            {
                var inputAbsolutePath = Path.Combine(bundleDir, filePath);

                // normalize possible wrong slashes
                var inputNormalizedPath = Path.GetFullPath((new Uri(inputAbsolutePath)).LocalPath);
                FileInfo inputFi = new FileInfo(inputNormalizedPath);

                BundleInput bundleInput = new BundleInput
                {
                    FullFilePath = inputNormalizedPath,
                    FileSize = inputFi.Length
                };

                inputList.Add(bundleInput);
            }

            return inputList;
        }

        private void AddToListView(Bundle[] bundles)
        {
            lvBundles.Items.Clear();

            foreach (var bundle in bundles)
            {
                // check for filter
                string filter = tsTxtFilter.Text.ToLower();
                if (!string.IsNullOrWhiteSpace(filter)) {

                    if (!bundle.OutputFileName.ToLower().Contains(filter)) {
                        continue;
                    }
                }

                // process the bundle
                long totalBundleSize = bundle.TotalBundleSize;
                
                string minificationEffect = "";
                long totalMinifiedSize = bundle.TotalMinifiedSize;
                if (totalMinifiedSize > 0) {
                    minificationEffect = $"Minified {totalMinifiedSize} bytes, savings of {bundle.MinifiedSavings.ToString("#0.##")}%";
                }

                ListViewItem lviBundleTitle = new ListViewItem();
                lviBundleTitle.Text = bundle.OutputFileName;
                lviBundleTitle.SubItems.Add(minificationEffect);
                lviBundleTitle.SubItems.Add(totalBundleSize.ToString());

                lviBundleTitle.Font = new System.Drawing.Font(lviBundleTitle.Font, System.Drawing.FontStyle.Bold);

                lvBundles.Items.Add(lviBundleTitle);

                foreach (var bundleInput in bundle.BundleInputs.OrderByDescending(bi => bi.FileSize))
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

        private void InitilizeMiscUI() {
            NativeMethods.SetToolstripTextBoxPlaceHolder(tsTxtFilter, "Filter Bundles");
        }

        private void FilterResults() {
            if (currentBundles != null) {
                AddToListView(currentBundles);
            }             
        }

        private void PrintToDebugWindow(Bundle[] bundles) {
            // print info
            foreach (var enrichedBundle in bundles) {
                long totalBundleSize = enrichedBundle.TotalBundleSize;
                Debug.Print($"{enrichedBundle.OutputFileName}. Total Size: {totalBundleSize} bytes");

                foreach (var bundleInput in enrichedBundle.BundleInputs.OrderByDescending(bi => bi.FileSize)) {
                    string fileTitle = bundleInput.FullFilePath.PadLeft(110);
                    string fileSize = bundleInput.FileSize.ToString().PadLeft(10);
                    string percent = bundleInput.PercentOfTotal.ToString("#0.##").PadLeft(4);

                    Debug.Print("\t" + $"{fileTitle}{fileSize} bytes, {percent}%");
                }

                Debug.Print("");
                Debug.Print("");
            }
        }

        #endregion
    }
}
