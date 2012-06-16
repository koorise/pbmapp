using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;

namespace PBMApp
{
    public partial class frm_bundle : Form
    {
        public frm_bundle()
        {
            InitializeComponent();
        }
        #region 按钮事件
        private void btnA_Click(object s, EventArgs e)
        {
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            
            foreach (ComboBoxItem cb in C_SelectPLU1.SelectedItems)
            {
                int pluid = int.Parse(cb.Value.ToString());
                Button b = (Button) s;
                int key = int.Parse(b.Name.Replace("button", ""));
                using (var m = new Entities())
                {
                    var q =
                        m.WH_Bundle_member.FirstOrDefault(
                            x => (x.BundleID == BundleID && x.PLUID == pluid));
                    q.KeyPosition = key;
                    m.SaveChanges();
                }  
            }
            Bind_CSelectPLU1();
        }
        private void btnB_Click(object s, EventArgs e)
        {
            int BundleID = C_cbBundleList.SelectedIndex + 1;

            foreach (ComboBoxItem cb in C_SelectPLU2.SelectedItems)
            {
                int pluid = int.Parse(cb.Value.ToString());
                Button b = (Button)s;
                int key = int.Parse(b.Name.Replace("b", ""));
                using (var m = new Entities())
                {
                    var q =
                        m.WH_Bundle_FreeOrDiscount.FirstOrDefault(
                            x => (x.BundleID == BundleID && x.PLUID == pluid && x.isFreeOrDiscount==1));
                    q.KeyPosition = key;
                    m.SaveChanges();
                }
            }
            Bind_CSelectPLU2();
        }
        private void btnC_Click(object s, EventArgs e)
        {
            int BundleID = C_cbBundleList.SelectedIndex + 1;

            foreach (ComboBoxItem cb in C_SelectPLU3.SelectedItems)
            {
                int pluid = int.Parse(cb.Value.ToString());
                Button b = (Button)s;
                int key = int.Parse(b.Name.Replace("e", ""));
                using (var m = new Entities())
                {
                    var q =
                        m.WH_Bundle_FreeOrDiscount.FirstOrDefault(
                            x => (x.BundleID == BundleID && x.PLUID == pluid && x.isFreeOrDiscount == 0));
                    q.KeyPosition = key;
                    m.SaveChanges();
                }
            }
            Bind_CSelectPLU3();
        }
        #endregion
        private void frm_bundle_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                #region ALL plu初始化
                var o = from c in m.WH_PLU
                        select c;
                foreach (var w in o)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID.ToString();
                    C_AllPLU1.Items.Add(cb);
                    C_AllPLU2.Items.Add(cb);
                    C_AllPLU3.Items.Add(cb);
                }
#endregion

                #region 促销信息初始化
                var q = from c in m.WH_Bundle
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                    //促销列表添加
                    ComboBoxItem cb=new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    C_cbBundleList.Items.Add(cb);  
                    
                }
                #endregion

                #region 按钮初始化
                for (int i = 1; i < 13; i++)
                {
                    Button btn = this.groupBox1.Controls["button" + i] as Button;
                    btn.Click += new EventHandler(btnA_Click);
                }
                for (int i = 1; i < 4; i++)
                {
                    Button btn = this.G4.Controls["b" + i] as Button;
                    btn.Click += new EventHandler(btnB_Click);
                }
                for (int i = 1; i < 4; i++)
                {
                    Button btn = this.G5.Controls["e" + i] as Button;
                    btn.Click += new EventHandler(btnC_Click);
                }
                #endregion
            }
            G1.Enabled = false;
            G2.Enabled = false;
            G3.Enabled = false;
            G4.Enabled = false;
            G5.Enabled = false;
        }

        private void C_cbBundleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = m.WH_Bundle.FirstOrDefault(x => x.ID == (C_cbBundleList.SelectedIndex + 1));
                C_cbType.SelectedIndex = int.Parse(q.TypeID.ToString()) - 1;
                C_tbDesc.Text = q.Description;
            }
        }

        private void C_cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int typeID = C_cbType.SelectedIndex + 1;
            for (int i = 1; i < 6; i++)
            {
                GroupBox gb = this.groupBox1.Controls["G" + i] as GroupBox;
                if (i == typeID)
                {
                    gb.Enabled = true;
                }
                else
                {
                    gb.Enabled = false;
                }
                foreach (Control c in gb.Controls)
                {
                    c.Text = "";
                }
            }
            using (var m = new Entities())
            {
                var q = m.WH_Bundle.FirstOrDefault(x => x.ID == (C_cbBundleList.SelectedIndex + 1));
                switch (C_cbType.SelectedIndex)
                {
                    case 0:
                        C_A_cbAmtQnt.SelectedIndex = int.Parse(q.isAmtOrQnt.ToString());
                        C_A_tbLimit.Text = q.Limit.ToString();
                        C_A_tbDiscount.Text = q.Discount.ToString();
                        break;
                    case 1:
                        C_B_tbFree.Text = q.Discount.ToString();
                        C_B_tbLimit.Text = q.Limit.ToString();
                        break;
                    case 2:
                        C_C_Limit.Text = q.Limit.ToString();
                        C_C_cbAmtQnt.SelectedIndex = int.Parse(q.isAmtOrQnt.ToString());
                        C_C_tbDiscount.Text = q.Discount.ToString();
                        break;
                    case 3:
                        //D 达到促销数量或者金额，可以从三个免费商品中任选一个
                        C_D_cbAmtQnt.SelectedIndex = int.Parse(q.isAmtOrQnt.ToString());
                        C_D_tbLimit.Text = q.Limit.ToString();
                        Bind_CSelectPLU2();
                        break;
                    case 4:
                        //E 达到促销数量，买制定的三个商品可以打折
                        C_E_tbDiscount.Text = q.Discount.ToString();
                        C_E_tbLimit.Text = q.Limit.ToString();
                        Bind_CSelectPLU3();
                        break;
                    default:
                        break;
                }

               
            }

        }

        private void C_AllPLU2_DoubleClick(object sender, EventArgs e)
        {
            
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                WH_Bundle_FreeOrDiscount b = new WH_Bundle_FreeOrDiscount();
                b.BundleID = BundleID;
                b.PLUID = int.Parse(((ComboBoxItem) C_AllPLU2.SelectedItem).Value.ToString());
                b.KeyPosition = 0;
                b.isFreeOrDiscount = 1;
                m.AddToWH_Bundle_FreeOrDiscount(b);
                m.SaveChanges();
            }
            Bind_CSelectPLU2();
        }

        private void C_SelectPLU2_DoubleClick(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                int BundleID = C_cbBundleList.SelectedIndex + 1;
                foreach (ComboBoxItem cb in C_SelectPLU2.SelectedItems)
                {
                    int pluid = int.Parse(cb.Value.ToString());
                    var q =
                        m.WH_Bundle_FreeOrDiscount.FirstOrDefault(
                            x => (x.BundleID == BundleID && x.PLUID == pluid && x.isFreeOrDiscount == 1));
                    m.DeleteObject(q);
                }
                m.SaveChanges();
            }
            Bind_CSelectPLU2();
        }

        /// <summary>
        /// Groupbox 4 绑定 combobox
        /// </summary>
        private void Bind_CSelectPLU2()
        {
            for (int i = 1; i < 4; i++)
            {
                Button btn = this.G4.Controls["b" + i] as Button;
                btn.Text = "";
            }

            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var r = from c in m.WH_Bundle_FreeOrDiscount
                        from d in m.WH_PLU
                        where c.BundleID == BundleID
                              && c.isFreeOrDiscount == 1
                              && c.PLUID == d.ID
                        select new
                        {
                            c.PLUID,
                            d.Description,
                            c.KeyPosition
                        };
                foreach (var w in r)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.PLUID;
                    C_SelectPLU3.Items.Add(cb);
                    if (w.KeyPosition != 0)
                    {
                        Button btn = this.G5.Controls["b" + w.KeyPosition] as Button;
                        btn.Text = w.Description.ToString();
                    }
                }

            }
        }

        private void C_AllPLU3_DoubleClick(object sender, EventArgs e)
        {
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                WH_Bundle_FreeOrDiscount b = new WH_Bundle_FreeOrDiscount();
                b.BundleID = BundleID;
                b.PLUID = int.Parse(((ComboBoxItem)C_AllPLU3.SelectedItem).Value.ToString());
                b.KeyPosition = 0;
                b.isFreeOrDiscount = 0;
                m.AddToWH_Bundle_FreeOrDiscount(b);
                m.SaveChanges();
            }
            Bind_CSelectPLU3();
        }

        private void C_SelectPLU3_DoubleClick(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                int BundleID = C_cbBundleList.SelectedIndex + 1;
                foreach (ComboBoxItem cb in C_SelectPLU3.SelectedItems)
                {
                    int pluid = int.Parse(cb.Value.ToString());
                    var q =
                        m.WH_Bundle_FreeOrDiscount.FirstOrDefault(
                            x => (x.BundleID == BundleID && x.PLUID == pluid && x.isFreeOrDiscount == 0));
                    m.DeleteObject(q);
                }
                m.SaveChanges();
            } 
            Bind_CSelectPLU3();
        }
        
        /// <summary>
        /// Groupbox 5 绑定 combobox
        /// </summary>
        private void Bind_CSelectPLU3()
        {
            for (int i = 1; i < 4; i++)
            {
                Button btn = this.G5.Controls["e" + i] as Button;
                btn.Text = "";
            }
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var r = from c in m.WH_Bundle_FreeOrDiscount
                        from d in m.WH_PLU
                        where c.BundleID == BundleID
                              && c.isFreeOrDiscount == 0
                              && c.PLUID == d.ID
                        select new
                        {
                            c.PLUID,
                            d.Description,
                            c.KeyPosition
                        };
                foreach (var w in r)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.PLUID;
                    C_SelectPLU3.Items.Add(cb);
                    if (w.KeyPosition != 0)
                    {
                        Button btn = this.G5.Controls["e" + w.KeyPosition] as Button;
                        btn.Text = w.Description.ToString();
                    }
                }
            }
        }

        private void C_SelectPLU1_DoubleClick(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                int BundleID = C_cbBundleList.SelectedIndex + 1;
                foreach (ComboBoxItem cb in C_SelectPLU1.SelectedItems)
                {
                    int pluid = int.Parse(cb.Value.ToString());
                    var q =
                        m.WH_Bundle_member.FirstOrDefault(
                            x => (x.BundleID == BundleID && x.PLUID == pluid ));
                    m.DeleteObject(q);
                }
                m.SaveChanges();
            }
            Bind_CSelectPLU1();
        }

        private void C_AllPLU1_DoubleClick(object sender, EventArgs e)
        {
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                WH_Bundle_member b = new WH_Bundle_member();
                b.BundleID = BundleID;
                b.PLUID = int.Parse(((ComboBoxItem)C_AllPLU1.SelectedItem).Value.ToString());
                b.KeyPosition = 0;
                m.AddToWH_Bundle_member(b);
                m.SaveChanges();
            }
            Bind_CSelectPLU1();
        }

        private void Bind_CSelectPLU1()
        {
            for (int i = 1; i < 13; i++)
            {
                Button btn = this.groupBox1.Controls["button" + i] as Button;
                btn.Text = "";
            }

            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var r = from c in m.WH_Bundle_member
                        from d in m.WH_PLU
                        where c.BundleID == BundleID 
                              && c.PLUID == d.ID
                        select new
                        {
                            c.PLUID,
                            d.Description,
                            c.KeyPosition
                        };
                foreach (var w in r)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.PLUID;
                    C_SelectPLU1.Items.Add(cb);
                    if (w.KeyPosition != 0)
                    {
                        Button btn = this.G5.Controls["button" + w.KeyPosition] as Button;
                        btn.Text = w.Description.ToString();
                    }
                }

            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var q = m.WH_Bundle.FirstOrDefault(x => x.ID == BundleID);
                q.Description = C_tbDesc.Text;
                q.TypeID = C_cbType.SelectedIndex+1;
                m.SaveChanges();
            }
        }
         
    }
}
