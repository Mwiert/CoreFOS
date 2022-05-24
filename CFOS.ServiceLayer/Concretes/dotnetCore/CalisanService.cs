using CFOS.DataAccessLayer.Conretes;
using CFOS.EntityLayer.Concretes;
using CFOS.ViewModelLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.ServiceLayer.Concretes.dotnetCore
{
    public class CalisanService : IDisposable
    {
        Customer customer = new Customer();
        Calisanlar calisan = new Calisanlar();
        CalisanVM calisanVM = new CalisanVM();
        public string viewStringController, viewStringAction;
        public (string,string,bool) Login(string username, string password)
        {
            try
            {
                UserVM userVM = new UserVM();
                AdminVM adminVM = new AdminVM();
                
                bool loginCheck = false;
                if (loginCheck != userVM.userLogin(username, password).Item1)
                {
                    customer = userVM.userLogin(username, password).Item2;
                    calisan = adminVM.CalisanSelectById(customer.UserId);
                    if (calisan.CalisanBiglileri.UserId == customer.UserId)
                    {
                        viewStringController = "Calisan";
                        viewStringAction = "Index";
                        loginCheck = true;
                    }
                    else
                    {
                        loginCheck = false;
                        viewStringController = "Login";
                        viewStringAction = "Index";
                    }
                }
                else
                {
                    loginCheck = false;
                    viewStringController = "Login";
                    viewStringAction = "Index";
                }
                return (viewStringController, viewStringAction, loginCheck);
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
                calisanVM.deleteOrder(id);
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
                calisanVM.deleteProduct(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void insertOrder(Order entity)
        {
            try
            {
                calisanVM.insertOrder(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void insertProdut(Product entity)
        {
            try
            {
                calisanVM.insertProdut(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Order> listOrder()
        {
            try
            {
                List<Order> orders = new List<Order>();
                orders=calisanVM.ListOrders();
                return orders;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Customer> listCustomer()
        {
            try
            {
                List<Customer> Customers = new List<Customer>();
                Customers = (List<Customer>)calisanVM.listCustomer();
                return Customers;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Product> listProduct()
        {
            try
            {
                List<Product> Products = new List<Product>();
                Products = (List<Product>)calisanVM.listProduct();
                return Products;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void updateProduct(int id, Product entity)
        {
            try
            {
                calisanVM.updateProduct(id, entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
