using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
namespace TraineesManagementSystem.Controllers
{
    public class SqlConnections
    {

        SqlConnection con = new SqlConnection("server=192.168.0.30;Initial Catalog=TraineesManagementDb;user=User5;Password=CDev005#8;TrustServerCertificate=True;User Instance=False;");

        public void Query(string query)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}
