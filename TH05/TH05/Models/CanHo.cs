using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TH05.Models
{
    public class CanHo
    {
        public CanHo()
        {
        }

        public CanHo(string maCanHo, string tenCanHo)
        {
            MaCanHo = maCanHo;
            TenCanHo = tenCanHo;
        }

        public string MaCanHo { get; set; }
        public string TenCanHo { get; set; }
    }
}
