using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBMApp
{
    public partial class frm_dept : Form
    {
        public frm_dept()
        {
            InitializeComponent();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seletedIndex = comboBox6.SelectedIndex;
            switch (seletedIndex)
            {
                case 0:
                    panel2.Enabled = true;
                    panel3.Enabled = false;
                    panel4.Enabled = false;
                    break;
                case 1:
                    panel2.Enabled = false;
                    panel3.Enabled = true;
                    panel4.Enabled = false;
                    break;
                case 2:
                    panel2.Enabled = false;
                    panel3.Enabled = false;
                    panel4.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
