using System.Data;
using System.Data.SqlClient;

namespace Fasetto.Word.Core
{
    public class PositionManager
    {
        public void SaveDesignation(DesignationItem myItem)
        {
            using (var db = DBConnection.CreateConnection())
            {
                db.Open();

                var sql = "dbo.spInsertPosition";
                var cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@POS_NAME", myItem._POS_NAME));
                cmd.Parameters.Add(new SqlParameter("@POS_DEPARTMENT", myItem._POS_DEPARTMENT));
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
