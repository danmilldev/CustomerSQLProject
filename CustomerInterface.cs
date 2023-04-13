using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSQLProject
{
    public class CustomerInterface
    {

        List<Customer> list = new();
        List<Product> product = new();
        List<Order> order = new();

        static string connectionString;

        CustomerInterface()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string connectionStringText = File.ReadAllText(Path.Combine(desktopPath + Path.DirectorySeparatorChar + "connectionstring.txt"));
            connectionString = connectionStringText;
        }

        //static void MethodHandler(Action methodName)
        //{
        //    using(SqlConnection conn = new(connectionString))
        //    {
        //        conn.Open();

        //        methodName?.Invoke();

        //        conn.Close();
        //    }
        //}

        public static void PrintResults()
        {
            using(SqlConnection conn = new(connectionString))
            {
                conn.Open();

                string readDataCommand = "";

                using(SqlCommand cmd = new(readDataCommand,conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                    }
                }

                conn.Close();
            }
        }



    }
}
