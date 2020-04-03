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
            this.tsBtnFileOpen});
            this.appToolbar.Location = new System.Drawing.Point(0, 0);
            this.appToolbar.Name = "appToolbar";
            this.appToolbar.Size = new System.Drawing.Size(1449, 33);
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
            this.tsBtnFileOpen.Text = "toolStripButton1";
            this.tsBtnFileOpen.Click += new System.EventHandler(this.tsBtnFileOpen_Click);
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
            this.lvBundles.HideSelection = false;
            this.lvBundles.Location = new System.Drawing.Point(0, 33);
            this.lvBundles.Name = "lvBundles";
            this.lvBundles.Size = new System.Drawing.Size(1449, 834);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 867);
            this.Controls.Add(this.lvBundles);
            this.Controls.Add(this.appToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Bundle Visualizer";
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
    }
}

