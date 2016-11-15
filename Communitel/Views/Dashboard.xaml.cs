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
using System.Windows.Shapes;
using Communitel.Views;

namespace Communitel.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public int user_profile_id { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            Login login = new Login();
            grdOverlay.Children.Add(login);
            grdMenu.Visibility = Visibility.Collapsed;
           
        }
        public void closeCurrent()
        {
            grdOverlay.Children.Clear();
            grdMenu.Visibility = Visibility.Visible;
            grdOverlay.Visibility = Visibility.Collapsed;
        }
        public void InitDashboard()
        {
            grdOverlay.Children.Clear();
            grdMenu.Visibility = Visibility.Visible;
            grdOverlay.Visibility = Visibility.Collapsed;
            dynamic user = App.Current.Properties["User"];
            dynamic dashboardContext = new System.Dynamic.ExpandoObject(); 
            dashboardContext.WelcomeFull = "Bienvenido, " + user.firstname+ " " + user.lastname;
            //txbWelcomeUser.DataContext = dashboardContext;
            int i = 1, j = 1;
            foreach (var item in user.userprofile.privileges)
            {
                Button grdMenuOption1 = new Button() { Background = new SolidColorBrush(Color.FromRgb(38, 50, 56)) };
                grdMenuOption1.Foreground = Brushes.White;
                grdMenuOption1.FontSize = 32;
                grdMenuOption1.Cursor = Cursors.Hand;
                grdMenuOption1.Click += new RoutedEventHandler(addMenuViews);
                grdMenuOption1.Content = item.views.description;
                grdMenuOption1.BorderBrush = null;
                grdMenu.Children.Add(grdMenuOption1);
                Grid.SetRow(grdMenuOption1, i);
                Grid.SetColumn(grdMenuOption1, 0);
                Grid.SetColumnSpan(grdMenuOption1, 12);
                Grid.SetRowSpan(grdMenuOption1, 1);
                i++;
            }

            
        }
        void addMenuViews(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.ToString().ToLower().CompareTo("configuration") == 0)
            {
                grdContent.Children.Clear();
                Configuration cng = new Configuration();
                grdContent.Children.Add(cng);
                //grdMenu.Visibility = Visibility.Collapsed;
                grdContent.Visibility = Visibility.Visible;
            }
            else if (((Button)sender).Content.ToString().ToLower().CompareTo("users") == 0)
            {
                grdContent.Children.Clear();
                dynamic gp = GetPrivilege("Users");
                Users cng = new Users(gp, user_profile_id);
                grdContent.Children.Add(cng);
                //grdMenu.Visibility = Visibility.Collapsed;
                grdContent.Visibility = Visibility.Visible;
            }
            else if (((Button)sender).Content.ToString().ToLower().CompareTo("inventory") == 0)
            {
                grdContent.Children.Clear();
                /*Configuration cng = new Configuration();
                grdOverlay.Children.Add(cng);
                grdMenu.Visibility = Visibility.Collapsed;
                grdOverlay.Visibility = Visibility.Visible;*/
            }
            if (((Button)sender).Content.ToString().ToLower().CompareTo("parameter") == 0)
            {
                grdContent.Children.Clear();
                /*Configuration cng = new Configuration();
                grdOverlay.Children.Add(cng);
                grdMenu.Visibility = Visibility.Collapsed;
                grdOverlay.Visibility = Visibility.Visible;*/
            }

        }
        private dynamic GetPrivilege(String description)
        {
            dynamic user = App.Current.Properties["User"];
            user_profile_id = (int)user.user_profile_id;
            foreach (var item in user.userprofile.privileges)
            {
                string viewName = item.views.description;
                if (viewName.Equals(description))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
