using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TH05.Models
{
    public class NV_BT
    {
        public NV_BT()
        {
        }

        public NV_BT(string maNhanVien, string maCanHo, string maThietBi, int lanThu, DateTime ngayBaoTri)
        {
            MaNhanVien = maNhanVien;
            MaCanHo = maCanHo;
            MaThietBi = maThietBi;
            LanThu = lanThu;
            NgayBaoTri = ngayBaoTri;
        }

        public string MaNhanVien { get; set; }
        public string MaCanHo { get; set; }
        public string MaThietBi { get; set; }
        public int LanThu { get; set; }
        public DateTime NgayBaoTri { get; set; }
    }
}
