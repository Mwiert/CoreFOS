using CFOS.DataAccessLayer.Abstractions;
using CFOS.DataAccessLayer.Conretes;
using CFOS.EntityLayer.Concretes;
using CFOS.Helpers.Concretes.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.ViewModelLayer.Concretes
{
    public class AdminVM
    {
        public bool adminLogin(string username, string password)
        {
            try
            {
                bool loginStatus = false;

                using (var repository = new AdminCRUD())
                {
                    loginStatus = repository.adminLogin(username, password);
                }
                return loginStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void deleteCalisan(int id)
        {
            try
            {
                using (var repository = new AdminCRUD())
                {
                    repository.DeleteCalisan(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int getLoginWithEmail(string username)
        {
            try
            {
                int id;
                using (var repository = new AdminCRUD())
                {
                    id = repository.GetIdWithEmail(username);
                }
                return id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int getLoginId(string username, string password)
        {
            try
            {
                int id;
                using (var repository = new AdminCRUD())
                {
                    id = repository.LoginIdAl(username, password);
                }
                return id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void deleteOrder(int id)
        {
            try
            {
                using (var repository = new AdminCRUD())
                {
                    repository.DeleteOrder(id);
                }
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
                using (var repository = new AdminCRUD())
                {
                    repository.DeleteProduct(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Calisanlar insert(Calisanlar entity)
        {
            try
            {
                Calisanlar calisanlar = new Calisanlar();
                using (var repository = new AdminCRUD())
                {
                    calisanlar = repository.insert(entity);
                }
                return calisanlar;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IList<Calisanlar> listCalisan()
        {
            try
            {
                IList<Calisanlar> calisanlars = new List<Calisanlar>();
                using (var repository = new AdminCRUD())
                {
                    calisanlars = repository.findAll();
                }
                return calisanlars;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Calisanlar CalisanSelectById(int id) // çalışanın bütün bilgilerini getirir
        {
            try
            {
                Calisanlar calisanlar = new Calisanlar();

                using (var repository = new AdminCRUD())
                {
                    calisanlar = repository.selectById(id);
                }
                return calisanlar;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Customer CustomerSelectById(int id)
        {
            Customer customer = new Customer();
            try
            {
                using (var repository = new AdminCRUD())
                {
                    customer = repository.customerSelectById(id);
                }
                return customer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //admin siparis update
        //admin urun update
        //admin urun ekle
        //admin siparis ekle
        // admini calisan tablosuna ekle  4 fonsiyon işlemlerini ::: adminin musteri kaydı bulunması gerekli!!
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
