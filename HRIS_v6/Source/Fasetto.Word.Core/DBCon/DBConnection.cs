using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    class DBConnection
    {
        public static SqlConnection CreateConnection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "HRIS",
                IntegratedSecurity = true
            };
            var db = new SqlConnection(builder.ToString());

            return db;
        }
    }
}
