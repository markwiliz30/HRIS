using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Fasetto.Word.Core
{
    public class EmployeeCollection
    {
        public void RetreiveAllEmployee()
        {
            StaticEmpoyeeCollection.staticEmployeeList.Clear();
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.GetEmployees";
                var cmd = new SqlCommand(sql, db);
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return;
                }

                while (reader.Read())
                {
                    var item = new EmployeeItem();

                    item._employeeId = (string)reader["Empolyee_ID"];
                    item._firstName = (string)reader["First_Name"];
                    item._middleName = (string)reader["Middle_Name"];
                    item._lastName = (string)reader["Last_Name"];
                    item._nationality = (string)reader["Nationality"];
                    item._eMail = (string)reader["Email"];
                    item._contactNum = (string)reader["Contact_Number"];
                    item._religion = (string)reader["Religion"];
                    item._presentAddress = (string)reader["Present_Address"];
                    item._permanentAddress = (string)reader["Permanent_Address"];

                    StaticEmpoyeeCollection.staticEmployeeList.Add(item);
                }

                db.Close();
            }
        }
    }
}
