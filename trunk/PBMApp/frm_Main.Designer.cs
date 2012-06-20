namespace PBMApp
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerFooterSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentRefundCouponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCASHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electronicScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deptSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cookingMessageSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bundleSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLUSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clerkSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.happyHourServiceTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.taxSettingToolStripMenuItem,
            this.deptSettingsToolStripMenuItem,
            this.menuSettingsToolStripMenuItem,
            this.cookingMessageSetToolStripMenuItem,
            this.bundleSettingsToolStripMenuItem,
            this.pLUSettingsToolStripMenuItem,
            this.clerkSettingsToolStripMenuItem,
            this.receiptToolStripMenuItem,
            this.optionToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            resources.ApplyResources(this.OpenToolStripMenuItem, "OpenToolStripMenuItem");
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.newDataBaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.openDataBaseToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerFooterSettingToolStripMenuItem,
            this.supplierSettingToolStripMenuItem,
            this.paymentRefundCouponToolStripMenuItem,
            this.pCASHToolStripMenuItem,
            this.electronicScaleToolStripMenuItem,
            this.happyHourServiceTaxToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            resources.ApplyResources(this.systemToolStripMenuItem, "systemToolStripMenuItem");
            // 
            // headerFooterSettingToolStripMenuItem
            // 
            this.headerFooterSettingToolStripMenuItem.Name = "headerFooterSettingToolStripMenuItem";
            resources.ApplyResources(this.headerFooterSettingToolStripMenuItem, "headerFooterSettingToolStripMenuItem");
            this.headerFooterSettingToolStripMenuItem.Click += new System.EventHandler(this.headerFooterSettingToolStripMenuItem_Click);
            // 
            // supplierSettingToolStripMenuItem
            // 
            this.supplierSettingToolStripMenuItem.Name = "supplierSettingToolStripMenuItem";
            resources.ApplyResources(this.supplierSettingToolStripMenuItem, "supplierSettingToolStripMenuItem");
            this.supplierSettingToolStripMenuItem.Click += new System.EventHandler(this.supplierSettingToolStripMenuItem_Click);
            // 
            // paymentRefundCouponToolStripMenuItem
            // 
            this.paymentRefundCouponToolStripMenuItem.Name = "paymentRefundCouponToolStripMenuItem";
            resources.ApplyResources(this.paymentRefundCouponToolStripMenuItem, "paymentRefundCouponToolStripMenuItem");
            this.paymentRefundCouponToolStripMenuItem.Click += new System.EventHandler(this.paymentRefundCouponToolStripMenuItem_Click);
            // 
            // pCASHToolStripMenuItem
            // 
            this.pCASHToolStripMenuItem.Name = "pCASHToolStripMenuItem";
            resources.ApplyResources(this.pCASHToolStripMenuItem, "pCASHToolStripMenuItem");
            this.pCASHToolStripMenuItem.Click += new System.EventHandler(this.pCASHToolStripMenuItem_Click);
            // 
            // electronicScaleToolStripMenuItem
            // 
            this.electronicScaleToolStripMenuItem.Name = "electronicScaleToolStripMenuItem";
            resources.ApplyResources(this.electronicScaleToolStripMenuItem, "electronicScaleToolStripMenuItem");
            this.electronicScaleToolStripMenuItem.Click += new System.EventHandler(this.electronicScaleToolStripMenuItem_Click);
            // 
            // taxSettingToolStripMenuItem
            // 
            this.taxSettingToolStripMenuItem.Name = "taxSettingToolStripMenuItem";
            resources.ApplyResources(this.taxSettingToolStripMenuItem, "taxSettingToolStripMenuItem");
            this.taxSettingToolStripMenuItem.Click += new System.EventHandler(this.taxSettingToolStripMenuItem_Click);
            // 
            // deptSettingsToolStripMenuItem
            // 
            this.deptSettingsToolStripMenuItem.Name = "deptSettingsToolStripMenuItem";
            resources.ApplyResources(this.deptSettingsToolStripMenuItem, "deptSettingsToolStripMenuItem");
            this.deptSettingsToolStripMenuItem.Click += new System.EventHandler(this.deptSettingsToolStripMenuItem_Click);
            // 
            // menuSettingsToolStripMenuItem
            // 
            this.menuSettingsToolStripMenuItem.Name = "menuSettingsToolStripMenuItem";
            resources.ApplyResources(this.menuSettingsToolStripMenuItem, "menuSettingsToolStripMenuItem");
            this.menuSettingsToolStripMenuItem.Click += new System.EventHandler(this.menuSettingsToolStripMenuItem_Click);
            // 
            // cookingMessageSetToolStripMenuItem
            // 
            this.cookingMessageSetToolStripMenuItem.Name = "cookingMessageSetToolStripMenuItem";
            resources.ApplyResources(this.cookingMessageSetToolStripMenuItem, "cookingMessageSetToolStripMenuItem");
            this.cookingMessageSetToolStripMenuItem.Click += new System.EventHandler(this.cookingMessageSetToolStripMenuItem_Click);
            // 
            // bundleSettingsToolStripMenuItem
            // 
            this.bundleSettingsToolStripMenuItem.Name = "bundleSettingsToolStripMenuItem";
            resources.ApplyResources(this.bundleSettingsToolStripMenuItem, "bundleSettingsToolStripMenuItem");
            this.bundleSettingsToolStripMenuItem.Click += new System.EventHandler(this.bundleSettingsToolStripMenuItem_Click);
            this.bundleSettingsToolStripMenuItem.DoubleClick += new System.EventHandler(this.bundleSettingsToolStripMenuItem_DoubleClick);
            // 
            // pLUSettingsToolStripMenuItem
            // 
            this.pLUSettingsToolStripMenuItem.Name = "pLUSettingsToolStripMenuItem";
            resources.ApplyResources(this.pLUSettingsToolStripMenuItem, "pLUSettingsToolStripMenuItem");
            this.pLUSettingsToolStripMenuItem.Click += new System.EventHandler(this.pLUSettingsToolStripMenuItem_Click);
            // 
            // clerkSettingsToolStripMenuItem
            // 
            this.clerkSettingsToolStripMenuItem.Name = "clerkSettingsToolStripMenuItem";
            resources.ApplyResources(this.clerkSettingsToolStripMenuItem, "clerkSettingsToolStripMenuItem");
            this.clerkSettingsToolStripMenuItem.Click += new System.EventHandler(this.clerkSettingsToolStripMenuItem_Click);
            // 
            // receiptToolStripMenuItem
            // 
            this.receiptToolStripMenuItem.Name = "receiptToolStripMenuItem";
            resources.ApplyResources(this.receiptToolStripMenuItem, "receiptToolStripMenuItem");
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.InitialDirectory = "Application.ExecutablePath";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // happyHourServiceTaxToolStripMenuItem
            // 
            this.happyHourServiceTaxToolStripMenuItem.Name = "happyHourServiceTaxToolStripMenuItem";
            resources.ApplyResources(this.happyHourServiceTaxToolStripMenuItem, "happyHourServiceTaxToolStripMenuItem");
            this.happyHourServiceTaxToolStripMenuItem.Click += new System.EventHandler(this.happyHourServiceTaxToolStripMenuItem_Click);
            // 
            // frm_Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem taxSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deptSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cookingMessageSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bundleSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLUSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clerkSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headerFooterSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentRefundCouponToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCASHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electronicScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem happyHourServiceTaxToolStripMenuItem;

    }
}