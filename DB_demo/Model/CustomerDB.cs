using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Model
{
    class CustomerDB
    {
       



        public ObservableCollection<Customer> GetCustomers(string connectionString)
        {
            string getCustomersQuery = "SELECT ID, FullName, Age, Weight, Height from Customers ORDER BY ID";

            var Customers = new ObservableCollection<Customer>();
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=FinalExamDB; Integrated Security=SSPI");


                conn.Open(); // Open the connection

                // TODO: Read the data from the database    

                // Check if the state is open
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        // Set the command's text property
                        cmd.CommandText = getCustomersQuery;

                        // Get the information (SqlDataReader)
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Use a while loop to keep reading the information
                        while (reader.Read())
                        {

                            Customer Customer = new Customer();

                            // Modify the properties of the object       
                            Customer.id = reader.GetInt32(0);
                            Customer.firstName =  reader.GetString(1); 
                            Customer.age = reader.GetInt32(2);
                            Customer.weight = reader.GetDouble(3);
                            Customer.height = reader.GetInt32(4);

                            

                            // Add the modified object to the collection
                            Customers.Add(Customer);
                            
                        }

                    }
                }


                return Customers;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }

            return null;

        }// End of GetCustomers method

        

    }
}
