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
///
using System.Windows.Threading;
using Microsoft.Win32;

namespace WpfMoveSpotLee
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly List<string> imagePaths = new List<string>
        {
            "Pic/gym.png",
            "Pic/pilates.webp",
            "Pic/pool.jpg",
            "Pic/yoga.jpg",
            "Pic/zumba2.jpg"
        };

        private int currentIndex = 0;
        private readonly DispatcherTimer timer = new DispatcherTimer();

        public HomePage()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += TimerTick; //אירוע 

            UpdateImage();

            timer.Start();
            //wv2.CoreWebView2InitializationCompleted += Wv2_CoreWebView2InitializationCompleted;

        }

        private void Wv2_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            
        }

        private void TimerTick (object sender , EventArgs e)
        {
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            UpdateImage();
        }

        private void UpdateImage()
        {
            string imagePath = imagePaths[currentIndex];
            ImageControl.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }

        private void Button_ClickNavActivity(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            // nav.Navigate(new UserControlActivity());
            nav.Navigate(new ActivityPage());
        }
    }
}
