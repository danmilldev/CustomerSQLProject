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
		List<Orders> orderList = new();

		static string connectionString;

		public CustomerInterface()
		{
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string connectionStringText = File.ReadAllText(Path.Combine(desktopPath + Path.DirectorySeparatorChar + "customerConnectionString.txt"));
			connectionString = connectionStringText;
		}

		public void PrintResults()
		{
			using(SqlConnection conn = new(connectionString))
			{
				conn.Open();

				string readDataCommand = @"SELECT o.OrderId AS OrderNumber,c.CustomerName AS Name, s.ProductName AS Product
										   FROM Orders AS o
										   JOIN Customers AS c
											ON c.CustomerId = o.CustomerId
										   JOIN Products AS s
											ON s.ProductId = o.ProductId;";

				using (SqlCommand cmd = new(readDataCommand,conn))
				{
					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							int orderNumber = reader.GetInt32(0);
							string customerName = reader.GetString(1);
							string productName = reader.GetString(2);

							orderList.Add(new Orders { OrderNumber = orderNumber,CustomerName = customerName, ProductName = productName });
						}
					}
				}

                Console.WriteLine("OrderNumber\tOrderName\t\tProductName");

                foreach (Orders order in orderList)
				{
                    Console.WriteLine(order.OrderNumber + "\t\t" + order.CustomerName + "\t\t\t" + order.ProductName);
                }

				conn.Close();
			}
		}

	}

	class Orders
	{
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
    }
}
