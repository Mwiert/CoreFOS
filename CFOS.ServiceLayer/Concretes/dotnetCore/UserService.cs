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
    public class UserService : IDisposable
    {
        Customer customer = new Customer();
        UserVM userVM = new UserVM();
        public (string, string, bool) UserLogin(string username, string password)
        {
            try
            {
                UserVM userVM = new UserVM();
                AdminVM adminVM = new AdminVM();
                string viewStringController, viewStringAction;
                bool loginCheck = false;
                if (loginCheck != userVM.userLogin(username, password).Item1)
                {
                    customer = userVM.userLogin(username, password).Item2;
                        loginCheck = true;
                        viewStringController = "User";
                        viewStringAction = "Index";                   
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
        public void insertOrder(Order entity)
        {
            try
            {
                userVM.insertOrder(entity);
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
                List<Order> orders = new List<Order>();
                orders = userVM.getOrderByUserId(id);
            return orders;
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
                userVM.deleteOrder(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void updateOrder(int id, Order update)
        {
            try
            {
                userVM.updateOrder(id, update);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void userRegister(Customer customer)
        {
            try
            {
                userVM.userRegister(customer);
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
