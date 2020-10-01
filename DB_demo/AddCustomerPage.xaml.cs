using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalExam
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddCustomerPage : Page
    {
        Customer customer = new Customer();

        public AddCustomerPage()
        {
            this.InitializeComponent();
        }
        private void onclick(object sender, RoutedEventArgs e)
        {
            ;

            try
            {
                txtMessage.Text = " "; //initialize txtBox Message 
                customer.ID = int.Parse(txtAddId.Text); // store id value into customer.ID
                customer.Age = int.Parse(txtAddAge.Text); // store age value into customer.Age
                customer.Weight = double.Parse(txtAddWeight.Text); // store weight value into customer.Weight
                customer.Height = int.Parse(txtAddHeight.Text); // store Height value into customer.Height

               

                try
                {
                    //Check if any textbox is empty
                    if (txtAddId.Text == "" || txtAddFName.Text == "" || txtAddLName.Text == "" || txtAddAge.Text == ""
                   || txtAddWeight.Text == "" || txtAddHeight.Text == "")
                    {
                        // If any textbox is empty throw exception
                        throw (new NoNullAllowedException(" Please fill all the TextBoxes. "));

                    }

                    //Check if age is less then 18
                    if (customer.Age < 18)
                    {
                        // If age is less then 18 throw exception
                        throw (new ArgumentOutOfRangeException("Enter age greater then 18."));
                    }

                    
                    string insertQuery = "INSERT INTO Customers(ID,FullName,Age,Weight,Height)" +
                        " VALUES('" + txtAddId.Text + "','" + txtAddFName.Text + " " + txtAddLName.Text + "'," +
                        "'" + txtAddAge.Text + "','" + txtAddWeight.Text + "','" + txtAddHeight.Text + "')";


                    // Connection to Database
                    SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=FinalExamDB; Integrated Security=SSPI");

                    con.Open(); // Open the connection

                    //TODO: Insert provided detials into database

                    //Check if the state is open
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        //Set  query and connection in SqlCommand
                        SqlCommand cmd = new SqlCommand(insertQuery, con);
                        //Command executes Query
                        cmd.ExecuteNonQuery();

                        con.Close();//Close the Connection

                    }

                    // Empty Textboxes 
                    txtAddId.Text = "";
                    txtAddFName.Text = " ";
                    txtAddLName.Text = " ";
                    txtAddAge.Text = "";
                    txtAddWeight.Text = "";
                    txtAddHeight.Text = "";

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }

            }
            catch (ArgumentOutOfRangeException) 
            {
                
                txtMessage.Text = " "; // empty txtMeassage
                txtMessage.Text = "Please enter valid values."; //ArgumentOutOfRangeException Message
            }
            catch (NoNullAllowedException)
            {
                txtMessage.Text = " ";// empty txtMessage
                txtMessage.Text = "Please fill all the TextBoxes. ";// NoNullAllowedException Message
            }
            catch (FormatException)
            {
                txtMessage.Text = " ";// empty txtMessage
                txtMessage.Text = "Please enter values in valid format. ";// FormatException Message
            }


            
        }

      

        private void navViewPage(object sender, RoutedEventArgs e)// Called on ViewPageButton
        {
            //Navigate to ViewCustomerPage
            this.Frame.Navigate(typeof(ViewCustomerPage));

        }
    }
}
