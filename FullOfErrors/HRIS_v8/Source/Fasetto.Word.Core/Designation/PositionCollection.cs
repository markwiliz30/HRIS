using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core.Designation
{
    public class PositionCollection
    {
        public void RetreiveAllPositions()
        {
            //StaticEmpoyeeCollection.staticEmployeeList.Clear();
            //using (var db = DBConnection.CreateConnection())
            //{
            //    db.Open();

            //    var sql = "dbo.GetEmployees";
            //    var cmd = new SqlCommand(sql, db);
            //    var reader = cmd.ExecuteReader();

            //    if (!reader.HasRows)
            //    {
            //        return;
            //    }

            //    while (reader.Read())
            //    {
            //        var item = new EmployeeItem();

            //        //item._employeeId = (string)reader["EMP_NO"];
            //        //item._firstName = (string)reader["FIRST_NAME"];
            //        //item._middleName = (string)reader["MIDDLE_NAME"];
            //        //item._lastName = (string)reader["LAST_NAME"];
            //        //item._nationality = (string)reader["NATIONALITY"];
            //        //item._eMail = (string)reader["EMAIL_ADDRESS"];
            //        //item._contactNum = (string)reader["CONTACT"];
            //        //item._religion = (string)reader["RELIGION"];
            //        //item._presentAddress = (string)reader["PRESENT_ADDRESS"];
            //        //item._permanentAddress = (string)reader["PERMANENT_ADDRESS"];

            //        StaticEmpoyeeCollection.staticEmployeeList.Add(item);
            //    }

            //    db.Close();
            }
        }
    }
}
