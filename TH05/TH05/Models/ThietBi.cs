using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TH05.Models
{
    public class ThietBi
    {
        public ThietBi()
        {
        }

        public ThietBi(string maThietBi, string tenThietBi)
        {
            MaThietBi = maThietBi;
            TenThietBi = tenThietBi;
        }

        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
    }
}
