using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.EntityLayer.Concretes
{
    public class Materials // ürün bilgileri burada
    {
        public int MalzemeId { get; set; }
        public double MalzemeUzunluk { get; set; }
        public string MalzemeAciklama { get; set; }
        public int MalzemeAdedi { get; set; }
    }
}
