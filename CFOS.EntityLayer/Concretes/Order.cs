using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.EntityLayer.Concretes
{
    public class Order
    {
        public int SiparisId { get; set; }
        public double TahminiSure { get; set; }
        public double TamamlanmaSuresi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public RawMaterial Hammadde { get; set; } //select +
        public CoatingInfo Kaplama { get; set; } //select  +
        public Machine Makine { get; set; } // +
        public bool Kesme { get; set; }
        public bool Taslama { get; set; }
        public bool Bileme { get; set; }
        public bool Kumlama { get; set; }
        public DateTime SevkTarihi { get; set; }
        public bool SevkDurumu { get; set; }
        public Calisanlar Calisan { get; set; } //+
        public Customer Musteri { get; set; }  //+ //Firma
        public Order()
        {
            Hammadde = new RawMaterial();
            Kaplama = new CoatingInfo();
            Makine = new Machine();
            Calisan = new Calisanlar();
            Musteri = new Customer();
        }
    }
}
