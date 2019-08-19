using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Fasetto.Word.Core
{
    public class UserPending
    {
        public void AddPending(PendingItem item)
        {
            using(var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.ADD_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", item.EMPID));
                cmd.Parameters.Add(new SqlParameter("@PENDING_TYPE", item.PENDING_TYPE));
                cmd.Parameters.Add(new SqlParameter("@PENDING_STATUS", item.PENDING_STATUS));
                cmd.Parameters.Add(new SqlParameter("@PENDING_DATE", item.PENDING_DATE));
                cmd.Parameters.Add(new SqlParameter("@PENDING_POSITION", item.PENDING_POSITION));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void GetPending(int empid)
        {
            using(var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.GET_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("EMP_ID", empid));
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return;
                }
                while (reader.Read())
                {
                    var item = new PendingItem();
                    item.PENDING_NAME = (string)reader["FIRST_NAME"];
                    item.PENDING_TYPE = (string)reader["PENDING_TYPE"];
                    item.PENDING_STATUS = (string)reader["PENDING_STATUS"];
                    item.PENDING_DATE = (string)reader["PENDING_DATE"];
                    item.PENDING_POSITION = (string)reader["PENDING_POSITION"];

                    StaticPendingList.staticPendingList.Add(item);
                }
                db.Close();
            }
        }

        public void RetrievePending()
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.GET_HEAD_APPROVAL";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return;
                }
                while (reader.Read())
                {
                    var item = new PendingItem();
                    item.PENDING_NAME = (string)reader["FIRST_NAME"];
                    item.PENDING_TYPE = (string)reader["PENDING_TYPE"];
                    item.PENDING_STATUS = (string)reader["PENDING_STATUS"];
                    item.PENDING_DATE = (string)reader["PENDING_DATE"];
                    item.PENDING_POSITION = (string)reader["PENDING_POSITION"];
                    StaticApprovalList.staticApprovalList.Add(item);

                }
                db.Close();
            }
        }
    }
}
