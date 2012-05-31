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
namespace PBMApp
{
    public partial class frm_PLU : Form
    {
        public frm_PLU()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable("dt");
            dt.Columns.Add("ino", typeof (string));
            dt.Columns.Add("description", typeof (string));

            for (int i = 0; i < 4; i++)
            {
                CookInfo c = new CookInfo();
                c.cookName = Guid.NewGuid().ToString();
                c.description = DateTime.Now.ToString();
                c.price = i;
                c.Save();
            }
            
            
             
            var q = from c in CookInfo.All()
                    select c;
            foreach (var CCC  in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = CCC.ID;
                dr[1] = CCC.cookName;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
        }

        
    }
}
