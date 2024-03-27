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
    /// Interaction logic for ActivityPage.xaml
    /// </summary>
    public partial class ActivityPage : Page
    {
        ActivityList activityList = new ActivityList();
        public ActivityPage()
        {
            InitializeComponent();
            GetAllActivity();
            if (LogIn.pManager == null)
            {
                insertAc.Visibility = Visibility.Collapsed;
            }
        }

        public async Task GetAllActivity ()
        {
            ApiService api1 = new ApiService();

            activityList = await api1.GetActivityList();

            List<UserControlActivity> listAUserControl = new List<UserControlActivity>();
            foreach (Activity a in activityList)
            {
                UserControlActivity b = new UserControlActivity(a);
                b.deleted += (sender, arg) =>
                {
                    listAUserControl.Remove(b);
                    this.ActivityGood.ItemsSource = null;
                    this.ActivityGood.ItemsSource = listAUserControl;
                };
                listAUserControl.Add(b);
            }

            this.ActivityGood.Visibility = Visibility.Visible;
            this.ActivityGood.ItemsSource = null;
            this.ActivityGood.ItemsSource = listAUserControl;
        }
        private void InsertActivity(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new InsertActivity());
        }

        //private async Task UserControlActivity()
        //{
        //    List<UserControlActivity> listAUserControl = new List<UserControlActivity>();
        //    foreach (Activity a in activityList)
        //    {
        //        listAUserControl.Add(new UserControlActivity(a));
        //    }
        //    this.ActivityGood.Visibility = Visibility.Visible;
        //    this.ActivityGood.ItemsSource = listAUserControl;
        //}

    }
}
