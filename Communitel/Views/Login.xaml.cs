using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Configuration;
using Communitel.Views;
using Communitel.helpers;
using System.Threading;
using Newtonsoft.Json;

namespace Communitel.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {

        public Login()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
                    }

        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            ProgressIndicator.IsBusy = true;
            ServiceRequest svc = new ServiceRequest();
            string parsedContent = "grant_type=password&client_id=" + ConfigurationManager.AppSettings["clientID"] + "&client_secret=" + ConfigurationManager.AppSettings["clientSecret"] + "&username=" + txtUsername.Text.ToLower() + "&password=" + txtPassword.Password + "&scope=";
            dynamic obj;
            Task.Factory.StartNew(() => {
                try
                {
                   obj = svc.requestToken("/oauth/token", parsedContent);
                    App.Current.Properties["Token"] = (string)obj.access_token;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }).ContinueWith((task) => {
                App.Current.Properties["User"] = svc.GET("/api/userIdentity/" + txtUsername.Text.ToLower());
                Dashboard dsh = ((Dashboard)((Grid)((Grid)this.Parent).Parent).Parent);
                dsh.InitDashboard();
                ProgressIndicator.IsBusy = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
