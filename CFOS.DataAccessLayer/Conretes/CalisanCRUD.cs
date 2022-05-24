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
    public class CalisanCRUD : ICalisanRepository<Product>, IDisposable
    {
        public string connectionString { get; set; }
        public bool loginStatus { get; set; }
        public CalisanCRUD()
        {
            connectionString = dbHelper.getConnectionString();
            loginStatus = false;
        }
        public (bool, Calisanlar) calisanLogin(string email, string password)
        {
            try
            {
                Calisanlar calisanlar = new Calisanlar();
                var query = new StringBuilder();

                query.Append("Select *from Customer where Customer UserEmail = @UserEmail AND UserPassword = @UserPassword");

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
                        dbHelper.AddParameter(command, "@UserPassword", password, DbType.String, ParameterDirection.Input);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int customerId = reader.GetInt32(0);

                                    loginStatus = true;

                                }
                            }
                        }
                    }
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
        public void deleteProduct(int id)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("DELETE FROM Urunler where UrunId=@UrunId");

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
        public Order insertOrder(Order Entity)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("INSERT into Siparisler ([SiparisId], [TahminiSure], [TamamlanmaSuresi], [SiparisTarihi], [Makine], [Hammadde],[Kaplama], [Kesme], [Taslama], [Bileme], [Kumlama], [SevkTarihi], [SevkDurumu], [SiparisAlanId], [SiparisOnaylayanId]) values (@UrunID, @TahminiSure, @TamamlanmaSuresi, @SiparisTarihi, @Makine, @Hammadde, @Kaplama, @Kesme, @Taslama, @Bileme, @Kumlama, @SevkTarihi, @SevkDurumu, @SiparisAlanId,@SiparisOnaylayanId)");
              
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

                        dbHelper.AddParameter(command, "@SiparisId", Entity.SiparisId, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@TahminiSure", Entity.TahminiSure, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@TamamlanmaSuresi", Entity.TamamlanmaSuresi, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@SiparisTarihi", Entity.SiparisTarihi, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Makine", Entity.Makine.MakineId, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Hammadde", Entity.Hammadde.HammaddeId, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Kesme", Entity.Kesme, DbType.Int32, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Taslama", Entity.Taslama, DbType.Int32, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Bileme", Entity.Bileme, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@Kumlama", Entity.Kumlama, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@SevkTarihi", Entity.SevkTarihi, DbType.Int32, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@SevkDurumu", Entity.SevkDurumu, DbType.Int32, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@SiparisAlanId", Entity.Calisan.CalisanId, DbType.Int32, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@SiparisOnaylayanId", Entity.Musteri.UserId, DbType.Int32, ParameterDirection.Input);


                        command.ExecuteNonQuery();
                    }
                }

                return Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Product insert(Product entity)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("INSERT into Urunler ([UrunAdi], [UrunKodu], [OnCap], [ArkaCap], [HelisBoyu], [HamBoy], [AgizSayisi], [HelisAcisi]) values (@UrunAdi, @UrunKodu, @OnCap, @ArkaCap, @HelisBoyu, @HamBoy, @AgizSayisi, @HelisAcisi)");

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

                        dbHelper.AddParameter(command, "@UrunAdi", entity.UrunAdi, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@UrunKodu", entity.UrunKodu, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@OnCap", entity.OnCap, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@ArkaCap", entity.ArkaCap, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@HelisBoyu", entity.HelisBoyu, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@HamBoy", entity.HamBoy, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@AgizSayisi", entity.AgizSayisi, DbType.Int32, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@HelisAcisi", entity.HelisAcisi, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IList<Product> listProducts()
        {
            try
            {
                List<Product> Products = new List<Product>();
                var query = new StringBuilder();

                query.Append("SELECT *From Urunler");

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
                                   Product Product = new Product();

                                    Product.UrunId = (int)reader["UrunId"];
                                    Product.UrunAdi = (string)reader["UrunAdi"];
                                    Product.UrunKodu = (string)reader["UrunKodu"];
                                    Product.OnCap = (double)reader["OnCap"];
                                    Product.ArkaCap = (double)reader["ArkaCap"];
                                    Product.HelisBoyu = (double)reader["HelisBoyu"];
                                    Product.HamBoy = (double)reader["HamBoy"];
                                    Product.AgizSayisi = (int)reader["AgizSayisi"];
                                    Product.HelisAcisi = (int)reader["HelisAcisi"];
                                    Products.Add(Product);
                                }
                            }
                        }

                    }
                }
                return Products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Product update(int id, Product updated)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("UPDATE Urunler SET UrunAdi =@UrunAdi , UrunKodu=@UrunKodu, OnCap=@OnCap, ArkaCap=@ArkaCap, HelisBoyu=@HelisBoyu, HamBoy=@HamBoy, AgizSayisi=@AgizSayisi, HelisAcisi = @HelisAcisi where UrunId=@UrunId");

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

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dbHelper.AddParameter(command, "@UrunId", id, DbType.Int32, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@UrunAdi", updated.UrunAdi, DbType.String, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@UrunKodu", updated.UrunKodu, DbType.String, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@OnCap", updated.OnCap, DbType.Double, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@ArkaCap", updated.ArkaCap, DbType.Double, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@HelisBoyu", updated.HelisBoyu, DbType.Double, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@HamBoy", updated.HamBoy, DbType.Double, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@AgizSayisi", updated.AgizSayisi, DbType.Int32, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@HelisAcisi", updated.HelisAcisi, DbType.Int32, ParameterDirection.Input);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return updated;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Order> ListOrder()
        {
            try
            {
                List<Order> orders = new List<Order>();
                var query = new StringBuilder();

                query.Append("Select  SiparisId, TahminiSure, TamamlanmaSuresi , SiparisTarihi , Kaplama , Makine ,Hammadde , Kesme , Taslama , Bileme , Kumlama , SevkTarihi , SevkDurumu , SiparisAlanId, SiparisOnaylayanId from Siparisler");
                 
                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(commandText))
                    {
                        if(dbConnection.State != ConnectionState.Open)
                        {
                            dbConnection.Open();
                        }

                        command.Connection = dbConnection;
                        using(var reader = command.ExecuteReader())
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
                            
                    }
                   }
                }
                return orders;
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
