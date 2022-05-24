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
    public class UserVM : IDisposable
    {
        public (bool, Customer) userLogin(string username, string password)
        {
            try
            {
                bool loginStatus = false;
                Customer customer = new Customer();
                using (var repository = new UserCRUD())
                {
                    loginStatus = repository.userLogin(username, password).Item1;
                    customer = repository.userLogin(username, password).Item2;
                }
                return (loginStatus, customer);
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
                using (var repository = new UserCRUD())
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
        public void deleteOrder(int id)
        {
            try
            {
                using (var repository = new UserCRUD())
                {
                    repository.deleteOrder(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Order updateOrder(int id, Order update)
        {
            try
            {
                Order order = new Order();
                using (var repository = new UserCRUD())
                {
                    order = repository.updateOrder(id, update);
                }
                return order;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Customer userRegister(Customer customer)
        {
            try
            {
                Customer customer1 = new Customer();
                using (var repository = new UserCRUD())
                {
                    customer1 = repository.UserRegister(customer);
                }
                return customer1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Order> getOrderByUserId(int id)
        {
            try
            {
                List<Order> Orders = new List<Order>();

                using (var repository = new UserCRUD())
                {
                    Orders = repository.GetOrderByUser(id);
                }

                return Orders;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
