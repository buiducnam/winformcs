using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.BUS;
using QLBanHang.DAL;

namespace QLBanHang.GUI
{
    public partial class frm_AD_QuanLyKho : Form
    {
        QuanLyBanHangEntities db;
        public frm_AD_QuanLyKho()
        {
            InitializeComponent();
            db = new QuanLyBanHangEntities();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTenKho.Text.Length > 1 && txtDiaChi.Text.Length > 5)
            {
                KHO kho = new KHO();
                kho.TENKHO = txtTenKho.Text;
                kho.DIACHI = txtDiaChi.Text;
                kho.MOTA = txtMoTa.Text;
                db.KHO.Add(kho);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công kho " + kho.TENKHO + "[" + kho.MAKHO + "]");
            }
        }

        private void frm_AD_QuanLyKho_Load(object sender, EventArgs e)
        {
            List<KHO> lstKho = (from c in db.KHO
                                select c).ToList();

            foreach (KHO item in lstKho)
            {
                ListViewItem lItem = new ListViewItem();
                lItem.Text = item.TENKHO + "[" + item.DIACHI + "]";
                lItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.MAKHO.ToString() });
                lItem.ImageIndex = 0;
                listView1.Items.Add(lItem);
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            long idKho = long.Parse(item.SubItems[1].Text);
            List<HANG> lstHang = (from c in db.HANG
                                  where c.MAKHO == idKho
                                  select c).ToList();
            hANGBindingSource.Clear();
            foreach (HANG itemHang in lstHang)
            {
                hANGBindingSource.Add(itemHang);
            }
        }


    }
}
