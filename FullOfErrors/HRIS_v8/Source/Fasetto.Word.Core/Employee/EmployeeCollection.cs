using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

                    item._EMP_NO = (string)reader["EMP_NO"];
                    item._FIRST_NAME = (string)reader["FIRST_NAME"];
                    item._MIDDLE_NAME = (string)reader["MIDDLE_NAME"];
                    item._LAST_NAME = (string)reader["LAST_NAME"];
                    item._EMP_PASSWORD = (string)reader["EMP_PASSWORD"];
                    item._GENDER = (string)reader["GENDER"];
                    item._BIRTHDAY = (string)reader["BIRTHDAY"];
                    item._NATIONALITY = (string)reader["NATIONALITY"];
                    item._PASSPORT = (string)reader["PASSPORT"];
                    item._RELIGION = (string)reader["RELIGION"];
                    item._BIRTH_PLACE = (string)reader["BIRTH_PLACE"];
                    item._EMP_STATUS = (string)reader["EMP_STATUS"];
                    item._EMAIL_ADDRESS = (string)reader["EMAIL_ADDRESS"];
                    item._CONTACT = (string)reader["CONTACT"];
                    item._PRESENT_ADDRESS = (string)reader["PRESENT_ADDRESS"];
                    item._PERMANENT_ADDRESS = (string)reader["PERMANENT_ADDRESS"];
                    item._DATE_JOINED = (string)reader["DATE_JOINED"];
                    item._END_PROVITION = (string)reader["END_PROVITION"];
                    item._POS_ID = (int)reader["POS_ID"];
                    item._IOE_PERSON = (string)reader["IOE_PERSON"];
                    item._IOE_RELATION = (string)reader["IOE_RELATION"];
                    item._IOE_ADDRESS = (string)reader["IOE_ADDRESS"];
                    item._IOE_CONTACT = (string)reader["IOE_CONTACT"];
                    item._HOURLY_RATE = double.Parse(reader["HOURLY_RATE"].ToString());
                    item._MONTHLY_SALARY = double.Parse(reader["MONTHLY_SALARY"].ToString());
                    item._SSS_NO = (string)reader["SSS_NO"];
                    item._PHIL_HEALTH_NO = (string)reader["PHIL_HEALTH_NO"];
                    item._PAG_IBIG_NO = (string)reader["PAG_IBIG_NO"];
                    item._BIR_NO = (string)reader["BIR_NO"];
                    item._DEDUC_SSS = double.Parse(reader["DEDUC_SSS"].ToString());
                    item._DEDUC_PHIL_HEALTH = double.Parse(reader["DEDUC_PHIL_HEALTH"].ToString());
                    item._DEDUC_PAG_IBIG = double.Parse(reader["DEDUC_PAG_IBIG"].ToString());
                    item._DEDUC_BIR = double.Parse(reader["DEDUC_BIR"].ToString());

                    StaticEmpoyeeCollection.staticEmployeeList.Add(item);
                }

                db.Close();
            }
        }

        public EmployeeItem RetreiveSpecificEmployee(string employeeID)
        {
            var item = new EmployeeItem();
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.GetSpecificEmployee";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Employee_ID", employeeID));
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                if (reader.Read())
                {
                    //item._employeeId = (string)reader["Empolyee_ID"];
                    //item._firstName = (string)reader["First_Name"];
                    //item._middleName = (string)reader["Middle_Name"];
                    //item._lastName = (string)reader["Last_Name"];
                    //item._nationality = (string)reader["Nationality"];
                    //item._eMail = (string)reader["Email"];
                    //item._contactNum = (string)reader["Contact_Number"];
                    //item._religion = (string)reader["Religion"];
                    //item._presentAddress = (string)reader["Present_Address"];
                    //item._permanentAddress = (string)reader["Permanent_Address"];
                }

                db.Close();

                return item;
            }
        }
    }
}
