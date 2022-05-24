using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFOS.EntityLayer.Concretes;
using System.Data.SqlClient;
using System.Data;
using CFOS.Helpers.Concretes.DBHelper;

namespace CFOS.DataAccessLayer.Conretes.OtherCRUD
{
    public class OtherCRUD : IDisposable
    {
        public string connectionString { get; set; }
        string RawMaterialName,CoatingName,MachineName;
        public OtherCRUD()
        {
            connectionString = dbHelper.getConnectionString();
        }
        public Materials materialAdd(Materials materials)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Insert into Malzeme ([MalzemeUzunluk], [MalzemeAciklama], [MalzemeAdedi]) values (@MalzemeUzunluk, @MalzemeAciklama ,@MalzemeAdedi)");
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
                        dbHelper.AddParameter(command, "@MalzemeUzunluk", materials.MalzemeUzunluk, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@MalzemeAciklama", materials.MalzemeAciklama, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@MalzemeAdedi", materials.MalzemeAdedi, DbType.Double, ParameterDirection.Input);
                        command.ExecuteNonQuery();
                    }
                }
                return materials;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Materials> materialList()
        {
            try
            {
                List<Materials> MaterialList = new List<Materials>();
                var query = new StringBuilder();

                query.Append("Select *from Malzeme");

                string CommandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(CommandText))
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
                                    Materials material = new Materials();
                                    material.MalzemeUzunluk = (double)reader["MalzemeUzunluk"];
                                    material.MalzemeAciklama = (string)reader["MalzemeAciklama"];
                                    material.MalzemeAdedi = (int)reader["MalzemeAdedi"];
                                    material.MalzemeId = (int)reader["MalzemeId"];

                                    MaterialList.Add(material);
                                }
                            }
                        }
                    }
                }
                return MaterialList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void materialDelete(int id)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Delete from Malzeme where MalzemeId=@MalzemeId");

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

                        dbHelper.AddParameter(command, "@MalzemeId", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public RawMaterial rawMaterialAdd(RawMaterial rawMaterial)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Insert into Hammaddeler ([HammaddeAdi], [HammaddeSeriNo], [HammaddeCap], [HammaddeBoy]) values  (@HammaddeAdi,@HammaddeSeriNo,@HammaddeCap,@HammaddeBoy)");
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
                        dbHelper.AddParameter(command, "@HammaddeAdi", rawMaterial.HammaddeAdi, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@HammaddeSeriNo", rawMaterial.HammaddeSeriNo, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@HammaddeCap", rawMaterial.HammaddeCap, DbType.Double, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@HammaddeBoy", rawMaterial.HammaddeBoy, DbType.Double, ParameterDirection.Input);
                        command.ExecuteNonQuery();
                    }
                }
                return rawMaterial;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<RawMaterial> rawMaterialList()
        {
            try
            {
                List<RawMaterial> rawMaterial = new List<RawMaterial>();
                var query = new StringBuilder();

                query.Append("Select *from Hammaddeler");

                string CommandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(CommandText))
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
                                    RawMaterial rawMate = new RawMaterial();
                                    rawMate.HammaddeId = (int)reader["HammaddeId"];
                                    rawMate.HammaddeAdi = (string)reader["HammaddeAdi"];
                                    rawMate.HammaddeSeriNo = (string)reader["HammaddeSeriNo"];
                                    rawMate.HammaddeCap = (double)reader["HammaddeCap"];
                                    rawMate.HammaddeBoy = (int)reader["HammaddeBoy"];

                                    rawMaterial.Add(rawMate);
                                }
                            }
                        }
                    }
                }
                return rawMaterial;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void rawMaterialDelete(int id)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Delete from Hammaddeler where HammaddeId=@HammaddeId");

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

                        dbHelper.AddParameter(command, "@HammaddeId", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void MachineDelete(int id)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Delete from Makineler where MakineId=@MakineId");

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

                        dbHelper.AddParameter(command, "@MakineId", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SameMachineByName(string MakineAdi)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("Select *from Makineler Where MakineAdi=@MakineAdi");

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
                        dbHelper.AddParameter(command, "@MakineAdi", MakineAdi, DbType.String, ParameterDirection.Input);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Machine MachineAdd(Machine machine)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Insert into Makineler ([MakineAdi]) values (@MakineAdi)");
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
                        dbHelper.AddParameter(command, "@MakineAdi", machine.MakineAdi, DbType.String, ParameterDirection.Input);
                        command.ExecuteNonQuery();
                    }
                }
                return machine;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Machine> MachineList()
        {
            try
            {
                List<Machine> machines = new List<Machine>();
                var query = new StringBuilder();

                query.Append("Select *from Makineler");

                string CommandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(CommandText))
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
                                    Machine machine = new Machine();

                                    machine.MakineId = (int)reader["MakineId"];
                                    machine.MakineAdi = (string)reader["MakineAdi"];

                                    machines.Add(machine);
                                }
                            }
                        }
                    }
                }
                return machines;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public CoatingInfo CoatingInfoUpdate(int id, CoatingInfo coatingInfo)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("Update KaplamaBilgileri SET ([KaplamaAdi],[(SevkTarihi)],[(TeslimTarihi)]) values ([@KaplamaAdi],[(@SevkTarihi)],[(@TeslimTarihi)]) where KaplamaNo=@KaplamaNo ");

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
                                dbHelper.AddParameter(command, "@KaplamaNo", id, DbType.Int32, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@KaplamaAdi", coatingInfo.KaplamaAdi, DbType.String, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@SevkTarihi", coatingInfo.SevkTarihi, DbType.DateTime, ParameterDirection.Input);
                                dbHelper.AddParameter(command, "@TeslimTarihi", coatingInfo.TeslimTarihi, DbType.DateTime, ParameterDirection.Input);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return coatingInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CoatingInfo CoatingInfoAdd(CoatingInfo coatingInfo)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("Insert into KaplamaBilgileri  ([KaplamaAdı], [SevkTarihi], [TeslimTarihi]) values (@KaplamaAdı, @SevkTarihi, @TeslimTarihi)");

                string commandtext = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(commandtext))
                    {
                        if (dbConnection.State != ConnectionState.Open)
                        {
                            dbConnection.Open();
                        }
                        command.Connection = dbConnection;

                        dbHelper.AddParameter(command, "@KaplamaAdı", coatingInfo.KaplamaAdi, DbType.String, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@SevkTarihi", coatingInfo.SevkTarihi, DbType.DateTime, ParameterDirection.Input);
                        dbHelper.AddParameter(command, "@TeslimTarihi", coatingInfo.TeslimTarihi, DbType.DateTime, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
                return coatingInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CoatingInfo> CoaingInfoListAll()
        {
            List<CoatingInfo> coatingInfoList = new List<CoatingInfo>();
            try
            {
                var query = new StringBuilder();

                query.Append("Select *From KaplamaBilgileri");

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
                                    CoatingInfo coatingInfo = new CoatingInfo();
                                    coatingInfo.KaplamaNo = (int)reader["KaplamaNo"];
                                    coatingInfo.KaplamaAdi = (string)reader["KaplamaAdı"];
                                    coatingInfo.SevkTarihi = (DateTime)reader["SevkTarihi"];
                                    coatingInfo.TeslimTarihi = (DateTime)reader["TeslimTarihi"];

                                    coatingInfoList.Add(coatingInfo);
                                }
                            }
                        }

                    }
                }
                return coatingInfoList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void CoatingInfoDelete(int id)
        {
            
            try
            {
                var query = new StringBuilder();

                query.Append("Delete from KaplamaBilgileri where KaplamaNo=@KaplamaNo");

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

                        dbHelper.AddParameter(command, "@KaplamaNo", id, DbType.Int32, ParameterDirection.Input);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string FindRawMaterialById(int id)
        {
            try
            {
                
                var query = new StringBuilder();

                query.Append("Select HammaddeAdi from Hammaddeler Where HammaddeId =@HammaddeId");
                
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

                        dbHelper.AddParameter(command, "@HammaddeId", id, DbType.String, ParameterDirection.Input);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    RawMaterialName = (string)reader["HammaddeAdi"];
                                }
                            }

                        }
                    }
                }
                return RawMaterialName;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string FindMachineById(int id)
        {
            try
            {

                var query = new StringBuilder();

                query.Append("Select MakineAdi from Makineler Where MakineId =@MakineId");

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

                        dbHelper.AddParameter(command, "@MakineId", id, DbType.String, ParameterDirection.Input);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    MachineName = (string)reader["MakineAdi"];
                                }
                            }

                        }
                    }
                }
                return MachineName;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string FindCoatingInfoById(int id)
        {
            try
            {

                var query = new StringBuilder();

                query.Append("Select KaplamaAdi from KaplamaBilgileri Where KaplamaNo =@KaplamaNo");

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

                        dbHelper.AddParameter(command, "@KaplamaNo", id, DbType.String, ParameterDirection.Input);


                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    CoatingName = (string)reader["KaplamaAdi"];
                                }
                            }

                        }
                    }
                }
                return CoatingName;
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
