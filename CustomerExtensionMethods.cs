using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSQLProject
{
    public class CustomerExtensionMethods
    {
        public static int? GetLastId(string tableName,string idName)
        {
            //SELECT MAX(Animal_Id) FROM Animal; would also have been possible to get the highest ID
            string getLastIdCommand = $"SELECT TOP 1 {idName} FROM {tableName} ORDER BY ID DESC;";

            using(SqlConnection conn = new(""))
            {
                conn.Open();

                using(SqlCommand cmd = new(getLastIdCommand,conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }

                conn.Close();
            }

            return null;
        }

    }
}
