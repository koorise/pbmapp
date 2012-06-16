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
    public partial class frm_bundleA : Form
    {
        public int t { get; set; }
        public frm_bundleA()
        {
            InitializeComponent();
        }

        private void frm_bundleA_Load(object sender, EventArgs e)
        {
            label1.Text = t.ToString();
        }
    }
}
