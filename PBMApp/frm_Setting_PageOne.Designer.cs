namespace PBMApp
{
    partial class frm_Setting_PageOne
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ColumnWidth = 300;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Print date on receipt ",
            "Print time on receipt",
            "Print clerk on receipt",
            "Print Header on receipt",
            "Print Footer on receipt",
            "Print Blank line on receipt",
            "Print Machine No. on receipt",
            "Print Receipt No. on receipt",
            "Print Tax amount on receipt",
            "Print Tax total on receipt",
            "Print item Tax code on receipt",
            "Print Vat analysis on receipt",
            "Print Vat No. on receipt",
            "Print Total Quantity on receipt",
            "Print Dept No. on receipt",
            "Print Local Currency symbol",
            "Print barcode when PLU sale",
            "Picture LOGO print",
            "Print cover on receipt",
            "Print slip header",
            "Print sign line",
            "Print food stamp mark",
            "Print average amount on receipt",
            "Print #/NS information",
            "print the sale receipt",
            "Consolidation same item RP",
            "KP print R.M. item",
            "Reprint receipt for R.M",
            "KP print Comp item",
            "Duplicate receipts allowed",
            "Print bill after transaction void",
            "Print bill after transfer table/combine table"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(728, 260);
            this.checkedListBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_Setting_PageOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "frm_Setting_PageOne";
            this.Text = "frm_Setting_PageOne";
            this.Load += new System.EventHandler(this.frm_Setting_PageOne_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
    }
}