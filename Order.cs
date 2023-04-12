using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSQLProject
{
    public class Order
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        int currentLastId { get; set; }

        Order()
        {
            CustomerExtensionMethods.GetLastId("SELECT TOP 1 * FROM Orders ORDER BY ID DESC;");
        }

        public static void CreateOrder()
        {

        }

        public static void DeleteOrder()
        {

        }

    }
}
