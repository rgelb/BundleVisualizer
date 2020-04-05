namespace BundleVisualizer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.appToolbar = new System.Windows.Forms.ToolStrip();
            this.tsBtnFileOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTxtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnFilter = new System.Windows.Forms.ToolStripButton();
            this.ofdBundle = new System.Windows.Forms.OpenFileDialog();
            this.lvBundles = new System.Windows.Forms.ListView();
            this.clnBundle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.appToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // appToolbar
            // 
            this.appToolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.appToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnFileOpen,
            this.toolStripSeparator1,
            this.tsTxtFilter,
            this.tsBtnFilter});
            this.appToolbar.Location = new System.Drawing.Point(0, 0);
            this.appToolbar.Name = "appToolbar";
            this.appToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.appToolbar.Size = new System.Drawing.Size(966, 33);
            this.appToolbar.TabIndex = 0;
            this.appToolbar.Text = "toolStrip1";
            // 
            // tsBtnFileOpen
            // 
            this.tsBtnFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFileOpen.Image")));
            this.tsBtnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFileOpen.Name = "tsBtnFileOpen";
            this.tsBtnFileOpen.Size = new System.Drawing.Size(34, 28);
            this.tsBtnFileOpen.Text = "Open bundleconfig.json";
            this.tsBtnFileOpen.Click += new System.EventHandler(this.tsBtnFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // tsTxtFilter
            // 
            this.tsTxtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsTxtFilter.Name = "tsTxtFilter";
            this.tsTxtFilter.Size = new System.Drawing.Size(130, 33);
            this.tsTxtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsTxtFilter_KeyDown);
            // 
            // tsBtnFilter
            // 
            this.tsBtnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnFilter.Image = global::BundleVisualizer.Properties.Resources.if_icon_111_search_314689;
            this.tsBtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFilter.Name = "tsBtnFilter";
            this.tsBtnFilter.Size = new System.Drawing.Size(34, 28);
            this.tsBtnFilter.Text = "toolStripButton1";
            this.tsBtnFilter.Click += new System.EventHandler(this.tsBtnFilter_Click);
            // 
            // ofdBundle
            // 
            this.ofdBundle.Filter = "Bundles (bundleconfig.json)|bundleconfig.json|All files (*.*)|*.*";
            // 
            // lvBundles
            // 
            this.lvBundles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnBundle,
            this.clnInput,
            this.clnSize,
            this.clnPercent});
            this.lvBundles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBundles.FullRowSelect = true;
            this.lvBundles.HideSelection = false;
            this.lvBundles.Location = new System.Drawing.Point(0, 33);
            this.lvBundles.Margin = new System.Windows.Forms.Padding(2);
            this.lvBundles.Name = "lvBundles";
            this.lvBundles.Size = new System.Drawing.Size(966, 531);
            this.lvBundles.TabIndex = 1;
            this.lvBundles.UseCompatibleStateImageBehavior = false;
            this.lvBundles.View = System.Windows.Forms.View.Details;
            // 
            // clnBundle
            // 
            this.clnBundle.Text = "Bundle";
            this.clnBundle.Width = 300;
            // 
            // clnInput
            // 
            this.clnInput.Text = "Input File";
            this.clnInput.Width = 300;
            // 
            // clnSize
            // 
            this.clnSize.Text = "Size";
            this.clnSize.Width = 150;
            // 
            // clnPercent
            // 
            this.clnPercent.Text = "Percent";
            this.clnPercent.Width = 100;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 564);
            this.Controls.Add(this.lvBundles);
            this.Controls.Add(this.appToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Bundle Visualizer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.appToolbar.ResumeLayout(false);
            this.appToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip appToolbar;
        private System.Windows.Forms.ToolStripButton tsBtnFileOpen;
        private System.Windows.Forms.OpenFileDialog ofdBundle;
        private System.Windows.Forms.ListView lvBundles;
        private System.Windows.Forms.ColumnHeader clnBundle;
        private System.Windows.Forms.ColumnHeader clnInput;
        private System.Windows.Forms.ColumnHeader clnSize;
        private System.Windows.Forms.ColumnHeader clnPercent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsTxtFilter;
        private System.Windows.Forms.ToolStripButton tsBtnFilter;
    }
}

