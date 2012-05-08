using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubSonic;
using PBM.DAL;
using SubSonic.Query;

namespace PBMApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var q = from c in Plot.All()
            //        orderby c.Id ascending 
            //        select c;

            PLU p=new PLU();
            

        }
    }
}
