using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static studentProject.Dal.SqlQuery;

namespace studentProject.Dal
{
    public class SqlQuery
    {
        public delegate object SetDataReader_delegate(SqlDataReader reader);
        public static object RunResCommand(string sql, SetDataReader_delegate func)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = sql;

                using (SqlCommand command = new SqlCommand(queryString, connection))
                { 
                     connection.Open();

                      using (SqlDataReader reader = command.ExecuteReader())
                      {
                         return func(reader);
                      }
                }
            }
        }
        public static void runCommand(string sql)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = sql;


                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery(); //return how many items was affected
                }

            }
        }

    }
   

}
