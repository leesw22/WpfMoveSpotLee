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
using Microsoft.Windows.Themes;
using System.Text.RegularExpressions;

namespace WpfMoveSpotLee
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    { 
        private readonly Regex regex = new Regex(@"^05\d{8}$");
        private readonly Regex regex2 = new Regex(@"^[a-zA-Z\p{IsHebrew}]+$");
        
        ServiceApiMoveSpot.ApiService cli;
        public Register()
        {
            InitializeComponent();
            cli = new ApiService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!regex.IsMatch(phone.Text.ToString()))
            {
                MessageBox.Show("phone number is not correct");
                return;
            }

            if (!regex2.IsMatch(firstName.Text))
            {
                MessageBox.Show("firstName is not correct");
                return;
            }

            if (!regex2.IsMatch(lastName.Text.ToString()))
            {
                MessageBox.Show("lastName is not correct");
                return;
            }

            if (await cli.Register(firstName.Text, lastName.Text, phone.Text, gender.SelectedIndex + 1) != null)
            {
                MessageBox.Show("good");
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new LogIn());
            }
            else
                MessageBox.Show(":(");

            //ApiService s = new ApiService();
            //Person p = new Person();
            //GenderList g = await s.GetGenderList();
            //p.FirstName = firstName.Text.ToString();
            //p.LastName = lastName.Text.ToString();
            //p.Phone = phone.Text.ToString();
            ////Lambda function
            //p.GenderName = g.Find(item => item.GenderName == gender.SelectedItem.ToString());
            //await s.InsertPerson(p);
           
        }
    }
}
