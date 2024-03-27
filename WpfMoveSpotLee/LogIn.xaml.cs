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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public static Person pManager;
        ApiService cli = new ApiService();
        public LogIn()
        {
            InitializeComponent();
            cli.GetActivityList(); 
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            Person p = await cli.LogIn(firstName.Text, lastName.Text, phone.Text);
            //if (p.FirstName == "לי" && p.LastName == "שוורץ" && p.Phone == "0533343603")

            if (p != null)
            {
                if (p.FirstName == "לי" && p.LastName == "שוורץ" && p.Phone == "0533343603")
                {
                    pManager = p;
                    MessageBox.Show("manager");
                }
                MessageBox.Show("good");
            }
            else
                MessageBox.Show(":(");
        }
    }
}
