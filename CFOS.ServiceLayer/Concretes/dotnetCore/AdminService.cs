using CFOS.EntityLayer.Concretes;
using CFOS.ViewModelLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CFOS.ServiceLayer.Concretes.dotnetCore
{
    public class AdminService
    {
        AdminVM adminVM = new AdminVM();
        Calisanlar calisanlar = new Calisanlar();
        Customer customer = new Customer();
        public (string,string,bool) adminLogin(string username, string password)
        {
            bool loginCheck = false;
            string viewStringController, viewStringAction;
            try
            {
                if (loginCheck != adminVM.adminLogin(username, password))
                {
                    viewStringController = "Admin";
                    viewStringAction = "Index";
                    loginCheck =true;
                }
                else
                {
                    viewStringController = "Login";
                    viewStringAction = "Index";
                }

                return (viewStringController,viewStringAction, loginCheck);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
            public int getUserIdWithEmail(string username)
        {
            try
            {
                return adminVM.getLoginWithEmail(username);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int getUserId(string username,string password)
        {
            try
            {
                return adminVM.getLoginId(username, password);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Customer getCustomerById(int id)
        {
            try
            {
             customer = adminVM.CustomerSelectById(id);
                return customer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void deleteCalisan(int id)
        {
            try
            {
               adminVM.deleteCalisan(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void deleteOrder(int id)
        {
            try
            {
                adminVM.deleteOrder(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public void deleteProduct(int id)
        {
            try
            {
                adminVM.deleteProduct(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public void insert(int id)
        {
            try
            {
                //Tablodan id gelir |-| veritabanından id ye ait customer bulunur
                customer = adminVM.CustomerSelectById(id);
                calisanlar.CalisanBiglileri.UserId = customer.UserId;
                calisanlar.CalisanBiglileri.UserAd = customer.UserAd;
                calisanlar.CalisanBiglileri.UserSoyad = customer.UserAd;
                calisanlar.CalisanBiglileri.UserAdress = customer.UserAdress;
                calisanlar.CalisanBiglileri.UserEmail = customer.UserEmail;
                calisanlar.CalisanBiglileri.UserPhoneNumber = customer.UserPhoneNumber;
                calisanlar.CalisanBiglileri.UserTcNo = customer.UserTcNo;
                //user list fonksiyonu olusturulmamis 
                adminVM.insert(calisanlar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Calisanlar> ListCalisan()
        {
            try
            {
                List<Calisanlar> calisanlars = new List<Calisanlar>();
                calisanlars = (List<Calisanlar>)adminVM.listCalisan();
                return calisanlars;
            }
            catch (Exception ex)
            {

                throw;
            }
       
        }
        public void CalisanSelectById(int id)
        {
            try
            {
                adminVM.CalisanSelectById(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
