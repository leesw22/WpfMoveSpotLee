using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for UpdateActivity.xaml
    /// </summary>
    public partial class UpdateActivity : Page
    {
        ApiService cli = new ApiService();
        Activity aNew;
        public UpdateActivity(Activity a)
        {
            aNew = a;
            InitializeComponent();
            this.nameActivity.Text = a.NameActivity;
            this.pricePremium.Text = a.PricePremium.ToString();
            this.priceNoPremium.Text = a.PriceNoPremium.ToString();
            this.timeLimit.Text = a.TimeLimit.ToString();
            //שמות של משתנים מXAML 
        }
        //public UpdateActivity()
        //{
        //}
            //public Execute() {
            //    a.NameActivity= this.nameActivity.Text
            //     cli.UpdateActivity(a);
            //}

            private async void ExecuteUpdate(object sender, RoutedEventArgs e)
        {
            aNew.NameActivity = this.nameActivity.Text;
            aNew.PricePremium =int.Parse( this.pricePremium.Text);
            aNew.PriceNoPremium = int.Parse(this.priceNoPremium.Text);
            aNew.TimeLimit = bool.Parse(this.timeLimit.Text);
            int num = await cli.UpdateActivity(aNew);

            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new UserControlActivity(aNew));
            NavigationService nav2 = NavigationService.GetNavigationService(this);
            nav2.Navigate(new ActivityPage());
        }
        //public UpdateActivity()
        //{
        //    InitializeComponent();
        //    cli = new ApiService();
        //}
    }
}
