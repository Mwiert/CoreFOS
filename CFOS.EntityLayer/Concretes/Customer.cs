using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.EntityLayer.Concretes
{
    public class Customer
    {
        public int UserId { get; set; }
        public string UserTcNo { get; set; }
        public string UserAd { get; set; }
        public string UserSoyad { get; set; }
        public string UserAdress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
