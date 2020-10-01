using FinalExam.Model;
using FinalExam.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalExam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // 1.1 Setup the Navigation back button
            SystemNavigationManager navMgr = SystemNavigationManager.GetForCurrentView();
            // 1.2 Register the navigation object with the event handler
            navMgr.BackRequested += OnNavigateBack;
            // 2. Display the back button
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;

        }


        private void OnNavigateBack(object sender, BackRequestedEventArgs e)
        {
            // Check if going backward is allowed
            if (frmContent.CanGoBack)
            {
                // Go backward
                frmContent.GoBack();

                // No Further Action is required
                e.Handled = true;
            }
        }


        private void OnClickItem(object sender, ItemClickEventArgs e)
        {

            // Find the item that is clicked
            NavMenuItem selectedItem = e.ClickedItem as NavMenuItem; // Capture the ClickedItem

            if (selectedItem.Label.Equals("Home")) // Find Item
            {

                // NOTE: we are not yet passing information between pages
                // Load the page in the child frame
                frmContent.Navigate(typeof(ViewCustomerPage)); //TODO: rename to meaningful name (HomePage)
            }

            else if (selectedItem.Label.Equals("Add Customer"))
            {
                // Load the page in the child frame
                frmContent.Navigate(typeof(AddCustomerPage)); // TODO: AddPage
            }

            else if (selectedItem.Label.Equals("Delete Customer"))
            {
                // Load the page in the child frame
                frmContent.Navigate(typeof(DeleteCustomerPage)); 
            }

        }

    }
}
