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
    public class CalisanVM : IDisposable
    {
        public (bool, Calisanlar) CalisanLogin(string username, string password)
        {
            try
            {
                bool loginStatus = false;
                Calisanlar calisanlar = new Calisanlar();
                using (var repository = new CalisanCRUD())
                {
                    loginStatus = repository.calisanLogin(username, password).Item1;
                    calisanlar = repository.calisanLogin(username, password).Item2;
                }
                return (loginStatus, calisanlar);
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
                using (var repository = new CalisanCRUD())
                {
                    repository.deleteOrder(id);
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
                using (var repository = new CalisanCRUD())
                {
                    repository.deleteProduct(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Order insertOrder(Order entity)
        {
            try
            {
                Order order = new Order();
                using (var repository = new CalisanCRUD())
                {
                    order = repository.insertOrder(entity);
                }
                return order;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Product insertProdut(Product entity)
        {
            try
            {
                Product product = new Product();
                using (var repository = new CalisanCRUD())
                {
                    product = repository.insert(entity);
                }
                return product;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Order> ListOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();
                using (var repository = new CalisanCRUD())
                {
                    orders = repository.ListOrder();
                }
                return orders;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IList<Product> listProduct()
        {
            try
            {
                List<Product> Products = new List<Product>();
                using (var repository = new CalisanCRUD())
                {
                    Products = (List<Product>)repository.listProducts();
                }
                return Products;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Product updateProduct(int id, Product entity)
        {
            try
            {
                Product product = new Product();
                using (var repository = new CalisanCRUD())
                {
                    product = repository.update(id, entity);
                }
                return product;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IList<Customer> listCustomer()
        {
            try
            {
                IList<Customer> Musteriler = new List<Customer>();
                using (var repository = new AdminCRUD())
                {
                    Musteriler = (IList<Customer>)repository.listCustomer();
                }
                return Musteriler;
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
