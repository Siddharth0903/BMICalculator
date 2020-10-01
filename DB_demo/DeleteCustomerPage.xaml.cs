using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalExam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DeleteCustomerPage : Page
    {
        
        Customer customer;
        CustomerDB dba = new CustomerDB();
        public DeleteCustomerPage()
        {
            this.InitializeComponent();
            

            // Initialize the list item source to load the student information
            customerList.ItemsSource = dba.GetCustomers((App.Current as App).connectionString);
        }

        private void OnClickItem(object sender, ItemClickEventArgs e)
        {
            //Select the clicked customer
            customer = e.ClickedItem as Customer;

            //Selceted customer details into readonly textbox
            txtId.Text = customer.id.ToString();// cusotmer id
            txtName.Text = customer.firstName; //customer name
            txtAge.Text = customer.age.ToString(); // customer Age
            txtWeight.Text = customer.weight.ToString(); // customer Weight
            txtHeight.Text = customer.height.ToString(); //customer Height
            txtBMI.Text = customer.BMI().ToString("N2"); // customer BMI
        }

        private void BtnDeleteFn(object sender, RoutedEventArgs e)
        {
            try
            {
                string insertQuery = "DELETE FROM Customers WHERE FullName = '"+customer.firstName+"' " ;

                // Connection to Database
                SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=FinalExamDB; Integrated Security=SSPI");

                con.Open(); // Open the connection

                //TODO: Delete customer details from database

                //Check if the state is open
                if (con.State == System.Data.ConnectionState.Open)
                {
                    //Set query and connection in SqlCommand
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    //Command executes Query
                    cmd.ExecuteNonQuery();

                    con.Close();//Close the Connection

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }

            // update the list view after customer deleted
            customerList.ItemsSource = dba.GetCustomers((App.Current as App).connectionString);

            // Empty Textboxes 
            txtId.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            txtBMI.Text = "";
        }

        private void navViewPage(object sender, RoutedEventArgs e)// Called on ViewButtonPage
        {
            //Navigate to ViewCustomerPage
            this.Frame.Navigate(typeof(ViewCustomerPage));

        }
    }
}
