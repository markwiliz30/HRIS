using System.Data;
using System.Data.SqlClient;

namespace Fasetto.Word.Core
{
    public class EmployeeManager
    {
        public void SaveData(EmployeeItem myItem)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.spInsertEmployee";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Empolyee_ID", myItem._employeeId));
                cmd.Parameters.Add(new SqlParameter("@First_Name", myItem._firstName));
                cmd.Parameters.Add(new SqlParameter("@Middle_Name", myItem._middleName));
                cmd.Parameters.Add(new SqlParameter("@Last_Name", myItem._lastName));
                cmd.Parameters.Add(new SqlParameter("@Nationality", myItem._nationality));
                cmd.Parameters.Add(new SqlParameter("@Religion", myItem._religion));
                cmd.Parameters.Add(new SqlParameter("@Email", myItem._eMail));
                cmd.Parameters.Add(new SqlParameter("@Contact_Number", myItem._contactNum));
                cmd.Parameters.Add(new SqlParameter("@Present_Address", myItem._presentAddress));
                cmd.Parameters.Add(new SqlParameter("@Permanent_Address", myItem._permanentAddress));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteData(string employeeID)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.spDeleteEmployee";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Employee_ID", employeeID));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void UpdateData(EmployeeItem item)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.spUpdateEmployee";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Employee_ID", item._employeeId));
                cmd.Parameters.Add(new SqlParameter("@First_Name", item._firstName));
                cmd.Parameters.Add(new SqlParameter("@Middle_Name", item._middleName));
                cmd.Parameters.Add(new SqlParameter("@Last_Name", item._lastName));
                cmd.Parameters.Add(new SqlParameter("@Nationality", item._nationality));
                cmd.Parameters.Add(new SqlParameter("@Religion", item._religion));
                cmd.Parameters.Add(new SqlParameter("@Email", item._eMail));
                cmd.Parameters.Add(new SqlParameter("@Contact_Number", item._contactNum));
                cmd.Parameters.Add(new SqlParameter("@Present_Address", item._presentAddress));
                cmd.Parameters.Add(new SqlParameter("@Permanent_Address", item._permanentAddress));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
