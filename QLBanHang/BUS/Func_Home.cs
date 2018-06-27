using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.DAL;

namespace QLBanHang.BUS
{
    class Func_Home
    {
        QuanLyBanHangEntities db;
        public Func_Home()
        {
            db = new QuanLyBanHangEntities();
        }
        public List<DonHangNew> getDonHangMoi()
        {
            List<HOADON> lst = null;
            try
            {
                lst = (from hd in db.HOADON
                       //join kh in db.KHACHHANG on hd.MAKH equals kh.MAKH
                       //join tk in db.TAIKHOAN on kh.MATAIKHOAN equals tk.MATAIKHOAN
                       select hd).ToList();
            }
            catch (Exception e) { }

            List<DonHangNew> resLst = new List<DonHangNew>();

            foreach (HOADON item in lst)
            {
                string tenKh = "Khách", tenNV;
                DonHangNew dhn;
                string tinhTrang;
                if (item.MAKH != null)
                {
                    tenKh = (from tk in db.TAIKHOAN
                             join kh in db.KHACHHANG on tk.MATAIKHOAN equals kh.MATAIKHOAN
                             where kh.MAKH == item.MAKH
                             select tk.TEN).Single().ToString();
                }
                tenNV = (from c in db.NHANVIEN
                         join tk in db.TAIKHOAN on c.MATAIKHOAN equals tk.MATAIKHOAN
                         where c.MANHANVIEN == item.MANHANVIEN
                         select tk.TEN).Single().ToString();
                if (item.TINHTRANG == 1)
                    tinhTrang = "Đã thanh toán";
                else
                    tinhTrang = "Chưa thanh toán";
                dhn = new DonHangNew
                {
                    maDonHang = item.MAHOADON,
                    ngayMua = item.NGAYLAP,
                    thanhTien = item.TONGTIEN,
                    tenKhachHang = tenKh,
                    tenNhanVien = tenNV,
                    tinhTrang = tinhTrang
                };
                resLst.Add(dhn);
            }

            return resLst;
        }

        public double getTongTienBanhang()
        {
            double tongTien = 0;
            List<HOADON> lst = (from c in db.HOADON
                                where c.NGAYLAP == DateTime.Now
                                select c).ToList();
            foreach (HOADON item in lst)
            {
                tongTien += item.TONGTIEN;
            }
            return tongTien;
        }
    }

    
}
