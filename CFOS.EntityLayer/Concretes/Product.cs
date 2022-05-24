using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.EntityLayer.Concretes
{
    public class Product
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunKodu { get; set; }
        public double OnCap { get; set; }
        public double ArkaCap { get; set; }
        public double HelisBoyu { get; set; }
        public double HamBoy { get; set; }
        public int AgizSayisi { get; set; }
        public int HelisAcisi { get; set; }
    }
}
