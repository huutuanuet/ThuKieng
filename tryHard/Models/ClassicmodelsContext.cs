using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryHard.Models
{
    public class ClassicmodelsContext
    {
        public string ConnectionString { get; set; }
        public ClassicmodelsContext(string ConnectionString) {
            this.ConnectionString = ConnectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Customer> GetAllCustomers() {
            List<Customer> customers = new List<Customer>();
            using (MySqlConnection conn = GetConnection()) {
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select * From customers", conn);
                using (MySqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read())
                    {
                        customers.Add(new Customer()
                        {
                            customerNumber = reader.GetInt32("customerNumber"),
                            customerName = reader.GetString("customerName"),
                            contactFirstName = reader.GetString("contactFirstName"),
                            contactLastName = reader.GetString("contactLastName"),
                            phone = reader.GetString("phone"),
                            addressLine1 = reader.GetString("addressLine1")

                        });
                    }
                }
            }

            return customers;
        }
    }
}
