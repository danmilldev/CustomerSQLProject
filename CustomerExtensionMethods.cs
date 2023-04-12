using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSQLProject
{
    public static class CustomerExtensionMethods
    {
        public static int GetLastId(string tableName)
        {
            string getLastIdCommand = "SELECT TOP 1 * FROM Orders ORDER BY ID DESC;";

            using(SqlConnection conn = new(""))
            {
                conn.Open();



                conn.Close();
            }

            return 0;
        }

    }
}
