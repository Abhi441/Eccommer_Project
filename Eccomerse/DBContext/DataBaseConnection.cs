using Microsoft.Data.SqlClient;
using System.Data;

namespace Eccomerse.DBContext
{
    public class DataBaseConnection
    {
        public static void Main(string[] args)
        {
            DataBaseConnection.Connection();

        }
           public static void Connection()
            {
                string cs = "Data Source=DESKTOP-S3ODLIB;Initial Catalog=Eccomerse;Integrated Security=true;";
                SqlConnection con = new SqlConnection(cs);

                con.Open();

                if(con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Successsfully");
                }
            else
            {
                Console.WriteLine("Not Successsfully");
            }
                con.Close();
            
        }
    }
}
