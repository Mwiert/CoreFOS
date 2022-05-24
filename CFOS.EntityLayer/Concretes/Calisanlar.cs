using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.EntityLayer.Concretes
{
    public class Calisanlar
    {
        public int CalisanId { get; set; }
        public Customer CalisanBiglileri { get; set; }
        public Calisanlar()
        {
            CalisanBiglileri = new Customer();
        }
    }
}
