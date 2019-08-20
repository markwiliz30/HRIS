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
        public void AddPending(PendingItem item,string reason)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.ADD_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", item.EMPID));
                cmd.Parameters.Add(new SqlParameter("@PENDING_TYPE", item.PENDING_TYPE));
                cmd.Parameters.Add(new SqlParameter("@PENDING_REASON", reason));
                cmd.Parameters.Add(new SqlParameter("@PENDING_STATUS", item.PENDING_STATUS));
                cmd.Parameters.Add(new SqlParameter("@PENDING_DATE", item.PENDING_DATE));
                cmd.Parameters.Add(new SqlParameter("@PENDING_POSITION", item.PENDING_POSITION));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void AddPendingOT(PendingItem item)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.ADD_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", item.EMPID));
                cmd.Parameters.Add(new SqlParameter("@PENDING_TYPE", item.PENDING_TYPE));
                cmd.Parameters.Add(new SqlParameter("@PENDING_REASON", item.PENDING_OT_REASON));
                cmd.Parameters.Add(new SqlParameter("@PENDING_STATUS", item.PENDING_STATUS));
                cmd.Parameters.Add(new SqlParameter("@PENDING_DATE", item.PENDING_DATE));
                cmd.Parameters.Add(new SqlParameter("@PENDING_POSITION", item.PENDING_POSITION));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void GetPending(int empid)
        {
            using (var db = DBConnection.CreateConnection())
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
                    item.PENDING_REASON = (string)reader["PENDING_REASON"];
                    item.PENDING_STATUS = (string)reader["PENDING_STATUS"];
                    item.PENDING_DATE = (string)reader["PENDING_DATE"];
                    item.PENDING_POSITION = (string)reader["PENDING_POSITION"];

                    StaticPendingList.staticPendingList.Add(item);
                }
                db.Close();
            }
        }

        public void RetrievePending(int id)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.GET_HEAD_APPROVAL";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", id));
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return;
                }
                while (reader.Read())
                {
                    var item = new PendingItem();
                    item.EMPID = (int)reader["EMP_ID"];
                    item.PENDING_NAME = (string)reader["FIRST_NAME"];
                    item.PENDING_TYPE = (string)reader["PENDING_TYPE"];
                    item.PENDING_REASON = (string)reader["PENDING_REASON"];
                    item.PENDING_STATUS = (string)reader["PENDING_STATUS"];
                    item.PENDING_DATE = (string)reader["PENDING_DATE"];
                    item.PENDING_POSITION = (string)reader["PENDING_POSITION"];

                    StaticApprovalList.staticApprovalList.Add(item);

                }
                db.Close();
            }
        }
        public void SpecificPendingLeave(int id, string type)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();
                var sql = "dbo.GET_SPECIFIC_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PENDING_ID", id));
                cmd.Parameters.Add(new SqlParameter("@PENDING_TYPE", type));
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return;
                }
                while (reader.Read())
                {
                    var item = new PendingItem();
                    item.PENDING_ID = (int)reader["PENDING_ID"];
                    item.EMPID = (int)reader["EMP_ID"];
                    item.PENDING_NAME = (string)reader["FIRST_NAME"];
                    item.PENDING_TYPE = (string)reader["PENDING_TYPE"];
                    item.PENDING_STATUS = (string)reader["PENDING_STATUS"];
                    item.PENDING_DATE = (string)reader["PENDING_DATE"];
                    item.PENDING_POSITION = (string)reader["PENDING_POSITION"];
                    item.PENDING_LEAVE_FROM = (string)reader["LEAVE_START"];
                    item.PENDING_LEAVE_TO = (string)reader["LEAVE_END"];
                    item.PENDING_LEAVE_REASON = (string)reader["REASON"];

                    StaticApprovalItem.staticApprovalModalItem = item;
                }
                db.Close();
            }
        }
        public void SpecificPendingOT(int id, string type)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();
                var sql = "dbo.GET_SPECIFIC_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", id));
                cmd.Parameters.Add(new SqlParameter("@PENDING_TYPE", type));
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return;
                }
                while (reader.Read())
                {
                    var item = new PendingItem();
                    item.EMPID = (int)reader["EMP_ID"];
                    item.PENDING_NAME = (string)reader["FIRST_NAME"];
                    item.PENDING_TYPE = (string)reader["PENDING_TYPE"];
                    item.PENDING_STATUS = (string)reader["PENDING_STATUS"];
                    item.PENDING_DATE = (string)reader["PENDING_DATE"];
                    item.PENDING_POSITION = (string)reader["PENDING_POSITION"];
                    item.PENDING_OT_FROM = (string)reader["TIME_FROM"];
                    item.PENDING_OT_TO = (string)reader["TIME_TO"];
                    item.PENDING_OT_REASON = (string)reader["OT_REASON"];
                    StaticApprovalItem.staticApprovalModalItem = item;
                }
                db.Close();
            }
        }
        public void Approve(string status , string appby , int id, string type , string sdate ,string reason) 
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.UPDATE_PENDING";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PENDING_STATUS", status));
                cmd.Parameters.Add(new SqlParameter("@APPROVED_BY", appby));
                cmd.Parameters.Add(new SqlParameter("@EMP_ID", id));
                cmd.Parameters.Add(new SqlParameter("@PENDING_TYPE", type));
                cmd.Parameters.Add(new SqlParameter("@PENDING_DATE", sdate));
                cmd.Parameters.Add(new SqlParameter("@PENDING_REASON", reason));
                cmd.ExecuteNonQuery();
                db.Close();

            }
        }
    }
}
