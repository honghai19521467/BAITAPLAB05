using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TH05.Models
{
    public class NhanVien
    {
        public NhanVien()
        {
        }

        public NhanVien(string maNhanVien, string tenNhanVien, string soDT, string gioiTinh)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            SoDT = soDT;
            GioiTinh = gioiTinh;
        }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDT { get; set; }
        public string GioiTinh { get; set; }

    }
}
