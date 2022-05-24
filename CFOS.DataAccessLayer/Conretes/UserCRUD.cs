using CFOS.DataAccessLayer.Abstractions;
using CFOS.EntityLayer.Concretes;
using CFOS.Helpers.Concretes.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CFOS.DataAccessLayer.Conretes
{
    public class UserCRUD : IDisposable
    {
        public string connectionString { get; set; }
        public bool loginStatus { get; set; }

        public UserCRUD()
        {
            connectionString = dbHelper.getConnectionString();
            loginStatus = false;
        }
        public (bool, Customer) userLogin(string email, string Password)
        {
            try
            {
                Customer customer = new Customer();

                var query = new StringBuilder();

                query.Append("SELECT *From Customer where UserEmail= @UserEmail AND UserPassword=@UserPassword");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    using (var command = new SqlCommand(commandText))
                    {
                        command.Connection = dbConnection;

                        dbHelper.AddParameter(command, "@UserEmail", email, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserPassword", Password, DbType.String, ParameterDirection.Input);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    customer.UserId = reader.GetInt32(0);
                                    customer.UserTcNo = reader.GetString(1);
                                    customer.UserAd = reader.GetString(2);
                                    customer.UserSoyad = reader.GetString(3);
                                    customer.UserAdress = reader.GetString(4);
                                    customer.UserPhoneNumber = reader.GetString(5);
                                    customer.UserEmail = reader.GetString(6);
                                    customer.UserPassword = reader.GetString(7);

                                    loginStatus = true;
                                }
                            }
                        }
                    }
                }
                return (loginStatus, customer);
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

        public Order insertOrder(Order entity)
        {
            try
            {
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Order> GetOrderByUser(int UserId)
        {
            try
            {
                List<Order> orders = new List<Order>();
                var query = new StringBuilder();

                query.Append("Select  SiparisId, TahminiSure, TamamlanmaSuresi , SiparisTarihi , Kaplama , Makine ,Hammadde , Kesme , Taslama , Bileme , Kumlama , SevkTarihi , SevkDurumu , SiparisAlanId, SiparisOnaylayanId from Siparisler where SiparisAlanId=@SiparisAlanId");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    using (var command = new SqlCommand(commandText))
                    {
                        command.Connection = dbConnection;

                        dbHelper.AddParameter(command, "@SiparisAlanId", UserId, DbType.Int32, ParameterDirection.Input);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Order order = new Order();
                                    order.Musteri.UserId = (int)reader["SiparisAlanId"];
                                    order.TahminiSure = (double)reader["TahminiSure"];
                                    order.SiparisTarihi = (DateTime)reader["SiparisTarihi"];
                                    order.SiparisId = (int)reader["SiparisId"];
                                    order.SevkDurumu = (bool)reader["SevkDurumu"];
                                    order.Kumlama = (bool)reader["Kumlama"];
                                    order.Taslama = (bool)reader["Taslama"];
                                    order.Bileme = (bool)reader["Bileme"];
                                    order.Kesme = (bool)reader["Kesme"];
                                    order.SevkTarihi = (DateTime)reader["SevkTarihi"];
                                    order.Kaplama.KaplamaNo = (int)reader["Kaplama"];
                                    order.Makine.MakineId = (int)reader["Makine"];
                                    order.TamamlanmaSuresi = (double)reader["TamamlanmaSuresi"];
                                    order.Hammadde.HammaddeId = (int)reader["Hammadde"];
                                    order.Calisan.CalisanId = (int)reader["SiparisOnaylayanId"];

                                    orders.Add(order);
                                }
                            }
                            return orders;
                        }
                    }
                }
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
                var query = new StringBuilder();
                query.Append("DELETE FROM Siparisler where SiparisId=@SiparisId");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    using (var command = new SqlCommand(commandText))
                    {
                        command.Connection = dbConnection;

                        dbHelper.AddParameter(command, "@SiparisId", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Order updateOrder(int id, Order updated)
        {
            try
            {
                return updated;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Customer UserRegister(Customer customer)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("INSERT into Customer ([UserTcNo], [UserAd], [UserSoyad], [UserAdress], [UserPhoneNumber], [UserEmail], [UserPassword]) values (@UserTcNo, @UserAd, @UserSoyad, @UserAdress, @UserPhoneNumber, @UserEmail, @UserPassword)");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    using (var command = new SqlCommand(commandText))
                    {
                        command.Connection = dbConnection;

                        dbHelper.AddParameter(command, "@UserTcNo", customer.UserTcNo, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserAd", customer.UserAd, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserSoyad", customer.UserSoyad, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserAdress", customer.UserAdress, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserPhoneNumber", customer.UserPhoneNumber, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserEmail", customer.UserEmail, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserPassword", customer.UserPassword, DbType.String, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
                return customer;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
