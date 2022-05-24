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
    public class AdminCRUD : IAdminrepository<Calisanlar>, IDisposable
    {
        public string connectionString { get; set; }
        public bool loginStatus { get; set; }
        int TempId;
        int CalisanIdTemp;
        public AdminCRUD()
        {
            connectionString = dbHelper.getConnectionString();

            loginStatus = false;
        }
        public bool adminLogin(string username, string password)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("SELECT *From Admin Where Username = @Username AND Password = @Password");

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

                        dbHelper.AddParameter(command, "@Username", username, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Password", password, DbType.String, ParameterDirection.Input);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    loginStatus = true;
                                }
                            }
                        }
                    }
                }
                return loginStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int GetIdWithEmail(string username)
        {
            try
            {

                var query = new StringBuilder();

                query.Append("SELECT UserId From Customer Where UserEmail = @UserEmail");

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

                        dbHelper.AddParameter(command, "@UserEmail", username, DbType.String, ParameterDirection.Input);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TempId = (int)reader["UserId"];
                                }
                            }

                        }
                    }
                }
                return TempId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int LoginIdAl(string username, string password)
        {
            try
            {
                
                var query = new StringBuilder();

                query.Append("SELECT UserId From Customer Where UserEmail = @UserEmail AND UserPassword = @UserPassword");

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

                        dbHelper.AddParameter(command, "@UserEmail", username, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UserPassword", password, DbType.String, ParameterDirection.Input);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    TempId = (int)reader["UserId"];
                                }
                            }
                            
                        }
                    }
                }
                return TempId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteCalisan(int id)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("DELETE from Calisanlar where CalisanId=@CalisanId");

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

                        dbHelper.AddParameter(command, "@CalisanId", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteOrder(int id)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Delete From Siparisler where SiparisId =@SiparisId");

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
        public void DeleteProduct(int id)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("DELETE from Urunler where UrunId=@UrunId");

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

                        dbHelper.AddParameter(command, "@UrunId", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IList<Calisanlar> findAll()
        {
            try
            {
                List<Calisanlar> calisanlarList = new List<Calisanlar>();
                var query = new StringBuilder();

                query.Append("select UserId,UserTcNo,UserAd,UserSoyad,UserAdress,UserPhoneNumber,UserEmail,CalisanId from Customer inner join Calisanlar on Customer.UserId = Calisanlar.CalisanNo");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(commandText))
                    {
                        if (dbConnection.State != ConnectionState.Open)
                        {
                            dbConnection.Open();
                        }
                        command.Connection = dbConnection;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Calisanlar calisanlar = new Calisanlar();

                                    calisanlar.CalisanBiglileri.UserId = (int)reader["UserId"];
                                    calisanlar.CalisanBiglileri.UserTcNo = (string)reader["UserTcNo"];
                                    calisanlar.CalisanBiglileri.UserAd = (string)reader["UserAd"];
                                    calisanlar.CalisanBiglileri.UserSoyad = (string)reader["UserSoyad"];
                                    calisanlar.CalisanBiglileri.UserAdress = (string)reader["UserAdress"];
                                    calisanlar.CalisanBiglileri.UserPhoneNumber = (string)reader["UserPhoneNumber"];
                                    calisanlar.CalisanBiglileri.UserEmail = (string)reader["UserEmail"];
                                    calisanlar.CalisanId = (int)reader["CalisanId"];
                                    calisanlarList.Add(calisanlar);
                                }
                            }
                        }

                    }
                }
                return calisanlarList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Calisanlar insert(Calisanlar Entity)
        {
            try
            {
                //var queryFirst = new StringBuilder();
                var querySecond = new StringBuilder();
                var queryThird = new StringBuilder();
                //query first Silinecek // register islemi beraber yapılmıyor.
                //queryFirst.Append("Insert into Customer ([UserTcNo], [UserAd], [UserSoyad], [UserAdress], [UserPhoneNumber], [UserEmail]) values (@UserTcNo, @UserAd, @UserSoyad, @UserAdress, @UserPhoneNumber, @UserEmail");
                querySecond.Append("Select ([UserId]) from Customer where UserTcNo = @UserTcNo"); //gereksiz satır
                queryThird.Append("Insert into Calisanlar ([CalisanNo]) values (@CalisanNo)");

                //string commandTextFirst = queryFirst.ToString();
                string commandTextSecond = querySecond.ToString();
                string commandTextThird = queryThird.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {

                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    //using (var command = new SqlCommand(commandTextFirst))
                    //{
                    //    command.Connection = dbConnection;

                    //    dbHelper.AddParameter(command, "@UserTcNo", Entity.CalisanBiglileri.UserTcNo, DbType.String, ParameterDirection.Input);
                    //    dbHelper.AddParameter(command, "@UserAd", Entity.CalisanBiglileri.UserAd, DbType.String, ParameterDirection.Input);
                    //    dbHelper.AddParameter(command, "@UserSoyad", Entity.CalisanBiglileri.UserSoyad, DbType.String, ParameterDirection.Input);
                    //    dbHelper.AddParameter(command, "@UserAdress", Entity.CalisanBiglileri.UserAdress, DbType.String, ParameterDirection.Input);
                    //    dbHelper.AddParameter(command, "@UserPhoneNumber", Entity.CalisanBiglileri.UserPhoneNumber, DbType.String, ParameterDirection.Input);
                    //    dbHelper.AddParameter(command, "@UserEmail", Entity.CalisanBiglileri.UserEmail, DbType.String, ParameterDirection.Input);
                    //    dbHelper.AddParameter(command, "@UserPassword", Entity.CalisanBiglileri.UserPassword, DbType.String, ParameterDirection.Input);

                    //    command.ExecuteNonQuery();
                    //}
                    using (var commandSecond = new SqlCommand(commandTextSecond))
                    {
                        commandSecond.Connection = dbConnection;

                        dbHelper.AddParameter(commandSecond, "@UserTcNo", Entity.CalisanBiglileri.UserTcNo, DbType.String, ParameterDirection.Input);

                        using (var reader = commandSecond.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    CalisanIdTemp =(int)reader["UserID"];
                                }
                            }
                        }

                    }

                    using (var commandThird = new SqlCommand(commandTextThird))
                    {
                        commandThird.Connection = dbConnection;

                        dbHelper.AddParameter(commandThird, "@CalisanNo", CalisanIdTemp, DbType.Int32, ParameterDirection.Input);

                        commandThird.ExecuteNonQuery();

                    }
                }
                return Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Customer customerSelectById(int id)
        {
            try
            {
                Customer customer = new Customer();

                var query = new StringBuilder();

                query.Append("SELECT UserId, UserTcNo, UserAd, UserSoyad, UserAdress, UserPhoneNumber, UserEmail FROM Customer where UserId=@UserId");

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
                        dbHelper.AddParameter(command, "@UserId", id, DbType.Int32, ParameterDirection.Input);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    customer.UserId = (int)reader["UserId"];
                                    customer.UserTcNo = (string)reader["UserTcNo"];
                                    customer.UserAd = (string)reader["UserAd"];
                                    customer.UserSoyad = (string)reader["UserSoyad"];
                                    customer.UserAdress = (string)reader["UserAdress"];
                                    customer.UserPhoneNumber = (string)reader["UserPhoneNumber"];
                                    customer.UserEmail = (string)reader["UserEmail"];
                                }
                            }
                        }
                    }
                }
                return customer;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Calisanlar selectById(int id)
        {
            try
            {
                Calisanlar calisanlar = new Calisanlar();

                var query = new StringBuilder();

                query.Append("SELECT UserId, UserTcNo, UserAd, UserSoyad, UserAdress, UserPhoneNumber, UserEmail FROM Customer INNER JOIN Calisanlar ON UserId=CalisanNo where CalisanNo = @CalisanNo");

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

                        dbHelper.AddParameter(command, "@CalisanNo", id, DbType.Int32, ParameterDirection.Input);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    calisanlar.CalisanBiglileri.UserId = (int)reader["UserId"];
                                    calisanlar.CalisanBiglileri.UserTcNo = (string)reader["UserTcNo"];
                                    calisanlar.CalisanBiglileri.UserAd = (string)reader["UserAd"];
                                    calisanlar.CalisanBiglileri.UserSoyad = (string)reader["UserSoyad"];
                                    calisanlar.CalisanBiglileri.UserAdress = (string)reader["UserAdress"];
                                    calisanlar.CalisanBiglileri.UserPhoneNumber = (string)reader["UserPhoneNumber"];
                                    calisanlar.CalisanBiglileri.UserEmail = (string)reader["UserEmail"];
                                }
                            }
                        }
                    }
                }
                return calisanlar;
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
                List<Customer> customerList = new List<Customer>();
                var query = new StringBuilder();

                query.Append("SELECT UserId, UserTcNo, UserAd, UserSoyad, UserAdress, UserPhoneNumber, UserEmail FROM Customer");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(commandText))
                    {
                        if (dbConnection.State != ConnectionState.Open)
                        {
                            dbConnection.Open();
                        }
                        command.Connection = dbConnection;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Customer customer = new Customer();

                                    customer.UserId = (int)reader["UserId"];
                                    customer.UserTcNo = (string)reader["UserTcNo"];
                                    customer.UserAd = (string)reader["UserAd"];
                                    customer.UserSoyad = (string)reader["UserSoyad"];
                                    customer.UserAdress = (string)reader["UserAdress"];
                                    customer.UserPhoneNumber = (string)reader["UserPhoneNumber"];
                                    customer.UserEmail = (string)reader["UserEmail"];

                                    customerList.Add(customer);
                                }
                            }
                        }

                    }
                }
                return customerList;
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
