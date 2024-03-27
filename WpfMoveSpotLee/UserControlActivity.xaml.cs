using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for UserControlActivity.xaml
    /// </summary>
    public partial class UserControlActivity : UserControl
    {
        public event EventHandler deleted;
        ApiService cli = new ApiService();
        public Activity currentActivity;
        public UserControlActivity(Activity a)
        {
            InitializeComponent();
            currentActivity = a;
            this.activityId.Text = a.Id.ToString();
            this.nameActivity.Text = a.NameActivity;
            this.priceNoPremium.Text = a.PriceNoPremium.ToString();
            this.pricePremium.Text = a.PricePremium.ToString();
            this.timeLimit.Text = a.TimeLimit.ToString();
            if (a.TimeLimit)
            {
                this.cb.IsChecked = true;
            }
            else
                this.cb.IsChecked = false;

            if(LogIn.pManager==null)
            {
                deleteAc.Visibility = Visibility.Collapsed;
                updateAc.Visibility = Visibility.Collapsed;
                //insertAc.Visibility = Visibility.Collapsed;
            }
        }

        private void showSomething(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi :)");
        }

        private void DeleteActivity(object sender, RoutedEventArgs e)
        {
            //if (cli.DeleteActivity(currentActivi)
            cli.DeleteActivity(currentActivity);
            deleted?.Invoke(null, EventArgs.Empty);
        }

        private void UpdateActivity(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new UpdateActivity(this.currentActivity));
            //NavigationService nav2 = NavigationService.GetNavigationService(this);
            //nav2.Navigate(new ActivityPage());
        }

        //private void InsertActivity(object sender, RoutedEventArgs e)
        //{
        //    NavigationService nav = NavigationService.GetNavigationService(this);
        //    nav.Navigate(new InsertActivity(this.currentActivity));
        //}

        //private void UpdateActivity(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
