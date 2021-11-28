using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TH05.Models
{
    public class Fixed
    {
        public Fixed()
        {
        }

        public Fixed(string tenNhanVien, string soDT, int lanThu)
        {
            TenNhanVien = tenNhanVien;
            SoDT = soDT;
            LanThu = lanThu;
        }

        public string TenNhanVien { get; set; }
        public string SoDT { get; set; }
        public int LanThu { get; set; }
    }
}
