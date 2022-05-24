using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.EntityLayer.Concretes
{
    public class CoatingInfo
    {
        public int KaplamaNo { get; set; }
        public string KaplamaAdi { get; set; }
        public DateTime SevkTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
    }
}
