namespace PBMApp
{
    partial class frm_Setting_ElectronicScale
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbTare = new System.Windows.Forms.TextBox();
            this.cbTare = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbTareType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbDept5 = new System.Windows.Forms.ComboBox();
            this.cbDept4 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbDept3 = new System.Windows.Forms.ComboBox();
            this.cbDept2 = new System.Windows.Forms.ComboBox();
            this.cbDept1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDots = new System.Windows.Forms.ComboBox();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.chkWA = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbWA = new System.Windows.Forms.ComboBox();
            this.cbID = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.tbTare);
            this.groupBox1.Controls.Add(this.cbTare);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cbTareType);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cbUnit);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.cbDept5);
            this.groupBox1.Controls.Add(this.cbDept4);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cbDept3);
            this.groupBox1.Controls.Add(this.cbDept2);
            this.groupBox1.Controls.Add(this.cbDept1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Electronic Scale ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(317, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Tare Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbTare
            // 
            this.tbTare.Location = new System.Drawing.Point(317, 98);
            this.tbTare.Name = "tbTare";
            this.tbTare.Size = new System.Drawing.Size(91, 21);
            this.tbTare.TabIndex = 19;
            // 
            // cbTare
            // 
            this.cbTare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTare.FormattingEnabled = true;
            this.cbTare.Location = new System.Drawing.Point(317, 71);
            this.cbTare.Name = "cbTare";
            this.cbTare.Size = new System.Drawing.Size(91, 20);
            this.cbTare.TabIndex = 18;
            this.cbTare.SelectedIndexChanged += new System.EventHandler(this.cbTare_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(282, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 17;
            this.label21.Text = "tare";
            // 
            // cbTareType
            // 
            this.cbTareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTareType.FormattingEnabled = true;
            this.cbTareType.Items.AddRange(new object[] {
            "automatic",
            "manual"});
            this.cbTareType.Location = new System.Drawing.Point(317, 44);
            this.cbTareType.Name = "cbTareType";
            this.cbTareType.Size = new System.Drawing.Size(91, 20);
            this.cbTareType.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(252, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 12);
            this.label20.TabIndex = 15;
            this.label20.Text = "Tare Type";
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "lb",
            "oz"});
            this.cbUnit.Location = new System.Drawing.Point(317, 17);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(90, 20);
            this.cbUnit.TabIndex = 14;
            this.cbUnit.SelectedIndexChanged += new System.EventHandler(this.cbUnit_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(282, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "Unit";
            // 
            // cbDept5
            // 
            this.cbDept5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept5.FormattingEnabled = true;
            this.cbDept5.Location = new System.Drawing.Point(119, 125);
            this.cbDept5.Name = "cbDept5";
            this.cbDept5.Size = new System.Drawing.Size(96, 20);
            this.cbDept5.TabIndex = 13;
            // 
            // cbDept4
            // 
            this.cbDept4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept4.FormattingEnabled = true;
            this.cbDept4.Location = new System.Drawing.Point(119, 98);
            this.cbDept4.Name = "cbDept4";
            this.cbDept4.Size = new System.Drawing.Size(96, 20);
            this.cbDept4.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 12);
            this.label18.TabIndex = 11;
            this.label18.Text = "Scale Department5";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 12);
            this.label17.TabIndex = 10;
            this.label17.Text = "Scale Department4";
            // 
            // cbDept3
            // 
            this.cbDept3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept3.FormattingEnabled = true;
            this.cbDept3.Location = new System.Drawing.Point(119, 71);
            this.cbDept3.Name = "cbDept3";
            this.cbDept3.Size = new System.Drawing.Size(96, 20);
            this.cbDept3.TabIndex = 9;
            // 
            // cbDept2
            // 
            this.cbDept2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept2.FormattingEnabled = true;
            this.cbDept2.Location = new System.Drawing.Point(119, 44);
            this.cbDept2.Name = "cbDept2";
            this.cbDept2.Size = new System.Drawing.Size(96, 20);
            this.cbDept2.TabIndex = 8;
            // 
            // cbDept1
            // 
            this.cbDept1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDept1.FormattingEnabled = true;
            this.cbDept1.Location = new System.Drawing.Point(119, 17);
            this.cbDept1.Name = "cbDept1";
            this.cbDept1.Size = new System.Drawing.Size(96, 20);
            this.cbDept1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(333, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scale Department3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scale Department2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale Department1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbID);
            this.groupBox2.Controls.Add(this.cbWA);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbDots);
            this.groupBox2.Controls.Add(this.tbBarcode);
            this.groupBox2.Controls.Add(this.chkWA);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Weighing PLU";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Decimal Dots";
            // 
            // cbDots
            // 
            this.cbDots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDots.FormattingEnabled = true;
            this.cbDots.Items.AddRange(new object[] {
            "None",
            "0",
            "0.0",
            "0.00",
            "0.000"});
            this.cbDots.Location = new System.Drawing.Point(143, 130);
            this.cbDots.Name = "cbDots";
            this.cbDots.Size = new System.Drawing.Size(87, 20);
            this.cbDots.TabIndex = 5;
            // 
            // tbBarcode
            // 
            this.tbBarcode.Location = new System.Drawing.Point(143, 74);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(100, 21);
            this.tbBarcode.TabIndex = 2;
            // 
            // chkWA
            // 
            this.chkWA.AutoSize = true;
            this.chkWA.Location = new System.Drawing.Point(143, 48);
            this.chkWA.Name = "chkWA";
            this.chkWA.Size = new System.Drawing.Size(96, 16);
            this.chkWA.TabIndex = 1;
            this.chkWA.Text = "Weighing PLU";
            this.chkWA.UseVisualStyleBackColor = true;
            this.chkWA.CheckedChanged += new System.EventHandler(this.chkWA_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "weight/amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Barcode length";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "ID";
            // 
            // cbWA
            // 
            this.cbWA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWA.FormattingEnabled = true;
            this.cbWA.Items.AddRange(new object[] {
            "amount",
            "weight"});
            this.cbWA.Location = new System.Drawing.Point(143, 102);
            this.cbWA.Name = "cbWA";
            this.cbWA.Size = new System.Drawing.Size(87, 20);
            this.cbWA.TabIndex = 18;
            this.cbWA.SelectedIndexChanged += new System.EventHandler(this.cbWA_SelectedIndexChanged);
            // 
            // cbID
            // 
            this.cbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbID.FormattingEnabled = true;
            this.cbID.Location = new System.Drawing.Point(143, 18);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(87, 20);
            this.cbID.TabIndex = 19;
            this.cbID.SelectedIndexChanged += new System.EventHandler(this.cbID_SelectedIndexChanged);
            // 
            // frm_Setting_ElectronicScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(445, 399);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_Setting_ElectronicScale";
            this.Text = "Setting Electronic Scale";
            this.Load += new System.EventHandler(this.frm_Setting_ElectronicScale_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.CheckBox chkWA;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDots;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbTare;
        private System.Windows.Forms.ComboBox cbTare;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbTareType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbDept5;
        private System.Windows.Forms.ComboBox cbDept4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbDept3;
        private System.Windows.Forms.ComboBox cbDept2;
        private System.Windows.Forms.ComboBox cbDept1;
        private System.Windows.Forms.ComboBox cbWA;
        private System.Windows.Forms.ComboBox cbID;
    }
}