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

namespace WpfMoveSpotLee
{
    /// <summary>
    /// Interaction logic for InsertActivity.xaml
    /// </summary>
    public partial class InsertActivity : Page
    {
        ServiceApiMoveSpot.ApiService cli = new ApiService();
        Activity aNew;
        public InsertActivity()
        {
            InitializeComponent();
            aNew = new();
            
        }

        private async void ExecuteInsert(object sender, RoutedEventArgs e)
        {
            aNew.NameActivity = this.nameActivity.Text;
            aNew.PricePremium = int.Parse(this.pricePremium.Text);
            aNew.PriceNoPremium = int.Parse(this.priceNoPremium.Text);
            aNew.TimeLimit = bool.Parse(this.timeLimit.Text);
            int num = await cli.InsertActivity(aNew);

            NavigationService nav2 = NavigationService.GetNavigationService(this);
            nav2.Navigate(new ActivityPage());
        }
    }
}
