//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADON
    {
        public HOADON()
        {
            this.CTHOADON = new HashSet<CTHOADON>();
        }
    
        public long MAHOADON { get; set; }
        public long MANHANVIEN { get; set; }
        public Nullable<long> MAKH { get; set; }
        public double TONGTIEN { get; set; }
        public System.DateTime NGAYLAP { get; set; }
        public byte TINHTRANG { get; set; }
        public Nullable<double> TIENKHACHTRA { get; set; }
        public Nullable<double> TIENTRALAIKHACH { get; set; }
    
        public virtual ICollection<CTHOADON> CTHOADON { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}