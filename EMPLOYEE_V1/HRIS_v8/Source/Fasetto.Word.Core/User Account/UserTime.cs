using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class UserTime
    {

        public void Time_in(TimeItem timeitem)
        {
            using(var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.ADD_ATTENDANCE";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", timeitem.EMP_ID));
                cmd.Parameters.Add(new SqlParameter("@TIME_IN", timeitem.TIME_IN));
                cmd.Parameters.Add(new SqlParameter("@TIME_OUT", timeitem.TIME_OUT));
                cmd.Parameters.Add(new SqlParameter("@LOG_DATE", timeitem.DATE));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public TimeItem Checker(int empid , string date)
        {
            var item = new TimeItem();
            using (var db= DBConnection.CreateConnection())
            {
                db.Open();
                var sql = "dbo.TIME_OUT_CHECKER";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", empid));
                cmd.Parameters.Add(new SqlParameter("@LOG_DATE", date));

                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                if (reader.Read())
                {
                    item.TIME_OUT = (string)reader["TIME_OUT"];
                    

                }
                db.Close();
                return item;

            }

        }

        public void Time_out(TimeItem timeitem)
        {
            using(var db = DBConnection.CreateConnection())
            {
                db.Open();
                var sql = "dbo.TIME_OUT";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TIME_OUT", timeitem.TIME_OUT));
                cmd.Parameters.Add(new SqlParameter("@LOG_TIME", timeitem.HOURS));
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", timeitem.EMP_ID));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
