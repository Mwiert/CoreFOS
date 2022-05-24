using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFOS.Helpers.Concretes.DBHelper
{
    public class dbHelper
    {
        public static string getConnectionString()
        {
            string connectionString = "Data Source=MWIERT;Initial Catalog=FOSystem;Integrated Security=True";
            return connectionString;

        }
        public static void AddParameter(DbCommand command, string parameterName,
                                               object parameterValue, DbType parameterType,
                                               ParameterDirection direction)
        {
            DbParameter parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            parameter.DbType = parameterType;
            parameter.Direction = direction;

            command.Parameters.Add(parameter);
        }
    }
}
