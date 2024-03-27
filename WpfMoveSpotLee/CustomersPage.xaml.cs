using Model;
using ServiceApiMoveSpot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using ServiceApiMoveSpot;

namespace WpfMoveSpotLee
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        private void InsertCustomers(object sender, RoutedEventArgs e)
        {

        }
        //CustomersList customersList = new CustomersList();
        //public CustomersPage()
        //{
        //    InitializeComponent();
        //    GetAllCustomers();
        //    if (LogIn.pManager == null)
        //    {
        //        insertCu.Visibility = Visibility.Collapsed;
        //    }
        //}

        //public async Task GetAllCustomers()
        //{
        //    ApiService api1 = new ApiService();

        //    customersList = await api1.GetCustomersList();

        //    List<UserControlCustomers> listAUserControl = new List<UserControlActivity>();
        //    foreach (Activity a in activityList)
        //    {
        //        UserControlActivity b = new UserControlActivity(a);
        //        b.deleted += (sender, arg) =>
        //        {
        //            listAUserControl.Remove(b);
        //            this.ActivityGood.ItemsSource = null;
        //            this.ActivityGood.ItemsSource = listAUserControl;
        //        };
        //        listAUserControl.Add(b);
        //    }

        //    this.ActivityGood.Visibility = Visibility.Visible;
        //    this.ActivityGood.ItemsSource = null;
        //    this.ActivityGood.ItemsSource = listAUserControl;
        //}
        //private void InsertActivity(object sender, RoutedEventArgs e)
        //{
        //    NavigationService nav = NavigationService.GetNavigationService(this);
        //    nav.Navigate(new InsertActivity());
        //}
    }
}
