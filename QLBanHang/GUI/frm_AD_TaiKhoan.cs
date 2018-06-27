using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.DAL;
using QLBanHang.BUS;

namespace QLBanHang.GUI
{
    public partial class frm_AD_TaiKhoan : Form
    {
        QuanLyBanHangEntities db;
        Func_TaiKhoan funcTK;
        public frm_AD_TaiKhoan()
        {
            InitializeComponent();
            funcTK = new Func_TaiKhoan();
            db = new QuanLyBanHangEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void loadTimTaiKhoan()
        {
            List<ThongTinKhachHang> lst = funcTK.timTaiKhoan(txtSearch.Text);
            if (lst != null)
            {
                thongTinKhachHangBindingSource.Clear();
                foreach (ThongTinKhachHang item in lst)
                {
                    thongTinKhachHangBindingSource.Add(item);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "clName_Edit")
                {
                    long maTaiKhoan = long.Parse(dataGridView1.Rows[e.RowIndex].Cells["clName_MaTaiKhoan"].Value.ToString());
                    TAIKHOAN tkEdit = db.TAIKHOAN.Single(p => p.MATAIKHOAN == maTaiKhoan);
                    
                    //Set taiKhoan len form
                    txtMaTaiKhoan.Text = tkEdit.MATAIKHOAN.ToString();
                    txt_Hoten.Text = tkEdit.TEN;
                    txt_Diachi.Text = tkEdit.DIACHI;
                    txtSDT.Text = tkEdit.SDT;
                    datetime_NgaySinh.Value = (DateTime)tkEdit.NGAYSINH;
                    if (cbGioiTinh.Items.Count == 0)
                    {
                        cbGioiTinh.Items.Add("Đàn bà");
                        cbGioiTinh.Items.Add("Đàn ông");
                    }
                    if (tkEdit.GIOITINH == true)
                        cbGioiTinh.SelectedIndex = 0;
                    else
                        cbGioiTinh.SelectedIndex = 1;
                    if (tkEdit.ISNHANVIEN == true)
                        checkBox_NhanVien.Checked = true;
                    else
                        checkBox_NhanVien.Checked = false;
                    //enable component
                    txt_Hoten.Enabled = true;
                    txt_Diachi.Enabled = true;
                    txtSDT.Enabled = true;
                    datetime_NgaySinh.Enabled = true;
                    cbGioiTinh.Enabled = true;
                    btnLuu.Enabled = true;
                    //checkBox_NhanVien.Enabled = true;


                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            long maTaiKhoan = 0;
            try
            {
                maTaiKhoan = long.Parse(txtMaTaiKhoan.Text);
            }
            catch (Exception ex) { }
            if (txtMaTaiKhoan.Text.Length > 0)
            {
                TAIKHOAN tk = null;
                try
                {
                    tk = db.TAIKHOAN.Single(p => p.MATAIKHOAN == maTaiKhoan);
                }
                catch (Exception ex) { }
                if (tk != null)
                {
                    tk.TEN = txt_Hoten.Text;
                    tk.DIACHI = txt_Diachi.Text;
                    tk.NGAYSINH = datetime_NgaySinh.Value;
                    tk.DIACHI = txt_Diachi.Text;
                    tk.SDT = txtSDT.Text;
                    if (checkBox_NhanVien.Checked == true)
                    {
                        tk.ISNHANVIEN = true;
                    }
                    else
                    {
                        tk.ISNHANVIEN = false;
                    }
                    if (cbGioiTinh.SelectedIndex == 0)
                    {
                        tk.GIOITINH = true;
                    }
                    else
                    {
                        tk.GIOITINH = false;
                    }
                    
                    db.SaveChanges();

                    MessageBox.Show("Chỉnh sửa thành công tài khoản ");
                }
            }
            else
            {
                TAIKHOAN tk = new TAIKHOAN();
                tk.TEN = txt_Hoten.Text;
                tk.DIACHI = txt_Diachi.Text;
                tk.NGAYSINH = datetime_NgaySinh.Value;
                tk.DIACHI = txt_Diachi.Text;
                if (cbGioiTinh.SelectedIndex == 0)
                {
                    tk.GIOITINH = true;
                }
                else
                {
                    tk.GIOITINH = false;
                }
                if (checkBox_NhanVien.Checked == true)
                {
                    tk.ISNHANVIEN = true;
                }
                else
                {
                    tk.ISNHANVIEN = false;
                }
                db.TAIKHOAN.Add(tk);
                db.SaveChanges();


                if (checkBox_NhanVien.Checked == true)
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.MATAIKHOAN = tk.MATAIKHOAN;
                    db.NHANVIEN.Add(nv);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công nhân viên có mã " + nv.MANHANVIEN);
                }
                else
                {
                    tk.ISNHANVIEN = false;
                    KHACHHANG kh = new KHACHHANG();
                    kh.MATAIKHOAN = tk.MATAIKHOAN;
                    db.KHACHHANG.Add(kh);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công khách hàng có mã " + kh.MAKH);
                }
            }
            loadTimTaiKhoan();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbGioiTinh.Items.Count ==0)
            {
                cbGioiTinh.Items.Add("Đàn bà");
                cbGioiTinh.Items.Add("Đàn ông");
            }
                
            txt_Hoten.Enabled = true;
            txt_Diachi.Enabled = true;
            txtSDT.Enabled = true;
            datetime_NgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
            btnLuu.Enabled = true;
            checkBox_NhanVien.Enabled = true;

            txtMaTaiKhoan.Text = "";
            txt_Hoten.Text = "";
            txt_Diachi.Text = "";
            txtSDT.Text = "";
            datetime_NgaySinh.Text = "01/01/1990";
            cbGioiTinh.SelectedIndex = 0;
            checkBox_NhanVien.Checked = false;
        }

        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                txt_Hoten.Enabled = false;
                txt_Diachi.Enabled = false;
                txtSDT.Enabled = false;
                datetime_NgaySinh.Enabled = false;
                cbGioiTinh.Enabled = false;
                btnLuu.Enabled = false;
                checkBox_NhanVien.Enabled = false;

                loadTimTaiKhoan();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
