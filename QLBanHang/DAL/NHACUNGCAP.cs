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
    
    public partial class NHACUNGCAP
    {
        public NHACUNGCAP()
        {
            this.HANG = new HashSet<HANG>();
        }
    
        public long MANCC { get; set; }
        public string TENNCC { get; set; }
        public string MOTA { get; set; }
    
        public virtual ICollection<HANG> HANG { get; set; }
    }
}
