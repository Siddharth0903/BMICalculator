using FinalExam.Model;
using System;
using System.Collections.Generic;
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
    public sealed partial class ViewCustomerPage : Page
    {
        public ViewCustomerPage()
        {
            this.InitializeComponent();
            CustomerDB dba = new CustomerDB();

            // Initialize the list item source to load the customer information
            customerList.ItemsSource = dba.GetCustomers((App.Current as App).connectionString);
        }

        private void OnClickItem(object sender, ItemClickEventArgs e)
        {
            //Select the clicked customer
            Customer customer = e.ClickedItem as Customer;

            //Selected customer details into readonly textbox

            txtId.Text = customer.id.ToString();// cusotmer id
            txtName.Text = customer.firstName; //customer name
            txtAge.Text = customer.age.ToString(); // customer Age
            txtWeight.Text = customer.weight.ToString(); // customer Weight
            txtHeight.Text = customer.height.ToString(); //customer Height
            txtBMI.Text = customer.BMI().ToString("N2"); // customer BMI
        }
    }
}
