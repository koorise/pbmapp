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
    public partial class frm_TouchScreen_Payment : Form
    {
        public frm_TouchScreen_Payment()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
