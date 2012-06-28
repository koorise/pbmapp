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

                MenuBind(0);
                #endregion

                 
            }
            
        }

        private void MenuBind(int index)
        {
            C_cbBundleList.Items.Clear();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Bundle
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                    //促销列表添加
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    C_cbBundleList.Items.Add(cb);
                }
            }
            C_cbBundleList.SelectedIndex = index;
        }

        private void C_cbBundleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = m.WH_Bundle.FirstOrDefault(x => x.ID == (C_cbBundleList.SelectedIndex + 1));
                C_cbType.SelectedIndex = int.Parse(q.TypeID.ToString()) - 1;
                C_tbDesc.Text = q.Description;
            }
            Bind_CSelectPLU1();
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
                        G1.Enabled = true;
                        G2.Enabled = false;
                        G3.Enabled = false;
                        G4.Enabled = false;
                        G5.Enabled = false;
                        break;
                    case 1:
                        C_B_tbFree.Text = q.Discount.ToString();
                        C_B_tbLimit.Text = q.Limit.ToString();
                        G1.Enabled = false;
                        G2.Enabled = true;
                        G3.Enabled = false;
                        G4.Enabled = false;
                        G5.Enabled = false;
                        break;
                    case 2:
                        C_C_Limit.Text = q.Limit.ToString();
                        C_C_cbAmtQnt.SelectedIndex = int.Parse(q.isAmtOrQnt.ToString());
                        C_C_tbDiscount.Text = q.Discount.ToString();
                        G1.Enabled = false;
                        G2.Enabled = false;
                        G3.Enabled = true;
                        G4.Enabled = false;
                        G5.Enabled = false;
                        break;
                    case 3:
                        //D 达到促销数量或者金额，可以从三个免费商品中任选一个
                        C_D_cbAmtQnt.SelectedIndex = int.Parse(q.isAmtOrQnt.ToString());
                        C_D_tbLimit.Text = q.Limit.ToString();
                        Bind_CSelectPLU2();
                        G1.Enabled = false;
                        G2.Enabled = false;
                        G3.Enabled = false;
                        G4.Enabled = true;
                        G5.Enabled = false;
                        break;

                    case 4:
                        //E 达到促销数量，买制定的三个商品可以打折
                        C_E_tbDiscount.Text = q.Discount.ToString();
                        C_E_tbLimit.Text = q.Limit.ToString();
                        Bind_CSelectPLU3();
                        G1.Enabled = false;
                        G2.Enabled = false;
                        G3.Enabled = false;
                        G4.Enabled = false;
                        G5.Enabled = true;
                        break;
                    default:
                        break;
                }
                q.TypeID = C_cbType.SelectedIndex + 1;
                m.SaveChanges();
            }

        }

        private void C_AllPLU2_DoubleClick(object sender, EventArgs e)
        { 
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                int result = (from c in m.WH_Bundle_FreeOrDiscount
                              where c.BundleID == BundleID && c.isFreeOrDiscount ==1
                              select c).Count();
                if (result < 3)
                {

                    WH_Bundle_FreeOrDiscount b = new WH_Bundle_FreeOrDiscount();
                    b.BundleID = BundleID;
                    b.PLUID = int.Parse(((ComboBoxItem) C_AllPLU2.SelectedItem).Value.ToString());
                    b.KeyPosition = 0;
                    b.isFreeOrDiscount = 1;
                    m.AddToWH_Bundle_FreeOrDiscount(b);
                    m.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Less than 3 plu allowed", "alert");
                }
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
            C_SelectPLU2.Items.Clear();
             

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
                    C_SelectPLU2.Items.Add(cb);
                }

            }
        }

        private void C_AllPLU3_DoubleClick(object sender, EventArgs e)
        {
            int BundleID = C_cbBundleList.SelectedIndex + 1;
            using (var m = new Entities())
            {
                int reuslt = (from c in m.WH_Bundle_FreeOrDiscount
                              where c.BundleID == BundleID && c.isFreeOrDiscount == 0
                              select c).Count();
                if (reuslt < 3)
                {
                    WH_Bundle_FreeOrDiscount b = new WH_Bundle_FreeOrDiscount();
                    b.BundleID = BundleID;
                    b.PLUID = int.Parse(((ComboBoxItem) C_AllPLU3.SelectedItem).Value.ToString());
                    b.KeyPosition = 0;
                    b.isFreeOrDiscount = 0;
                    m.AddToWH_Bundle_FreeOrDiscount(b);
                    m.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Less than 3 plu allowed", "alert");
                }
            }
            Bind_CSelectPLU3();
        }

        private void C_SelectPLU3_DoubleClick(object sender, EventArgs e)
        {
            C_SelectPLU3.Items.Clear();
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
                int result = (from c in m.WH_Bundle_member
                              where c.BundleID == BundleID
                              select c).Count();
                if (result <= 12)
                {
                    WH_Bundle_member b = new WH_Bundle_member();
                    b.BundleID = BundleID;
                    b.PLUID = int.Parse(((ComboBoxItem) C_AllPLU1.SelectedItem).Value.ToString());
                    b.KeyPosition = 0;
                    m.AddToWH_Bundle_member(b);
                    m.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Less than 12 plu allowed", "alert");
                }
            }
            Bind_CSelectPLU1();
        }

        private void Bind_CSelectPLU1()
        {
            C_SelectPLU1.Items.Clear();
            

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
                q.TypeID = C_cbType.SelectedIndex + 1;
                switch (C_cbType.SelectedIndex)
                {
                    case 0:
                        q.isAmtOrQnt = C_A_cbAmtQnt.SelectedIndex;
                        q.Limit = decimal.Parse(C_A_tbLimit.Text);
                        q.Discount = decimal.Parse(C_A_tbDiscount.Text);
                        break;
                    case 1:
                        q.Discount = decimal.Parse(C_B_tbFree.Text);
                        q.Limit = decimal.Parse(C_B_tbLimit.Text);
                        break;
                    case 2:
                        q.Limit = decimal.Parse(C_C_Limit.Text);
                        q.isAmtOrQnt = C_C_cbAmtQnt.SelectedIndex;
                        q.Discount = int.Parse(C_C_tbDiscount.Text);
                        break;
                    case 3:
                        //D 达到促销数量或者金额，可以从三个免费商品中任选一个
                        q.isAmtOrQnt = C_D_cbAmtQnt.SelectedIndex;
                        q.Limit = decimal.Parse(C_D_tbLimit.Text);
                        Bind_CSelectPLU2();
                        break;
                    case 4:
                        //E 达到促销数量，买制定的三个商品可以打折
                        q.Discount = decimal.Parse(C_E_tbDiscount.Text);
                        q.Limit = decimal.Parse(C_E_tbLimit.Text);
                        Bind_CSelectPLU3();
                        break;
                    default:
                        break;
                }
                m.SaveChanges();
            }
            MenuBind(BundleID-1);
            MessageBox.Show("success!", "alert");
        }

        private void C_B_tbFree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void C_A_tbDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void C_A_tbLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void C_C_Limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void C_D_tbLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void C_E_tbLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void C_E_tbDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

       
         
    }
}
