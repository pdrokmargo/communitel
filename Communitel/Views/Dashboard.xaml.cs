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
        public int profile_id { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            Login login = new Login();
            grdOverlay.Children.Add(login);
            grdMenu.Visibility = Visibility.Collapsed;

        }
        public void InitDashboard()
        {
            grdOverlay.Children.Clear();
            grdMenu.Visibility = Visibility.Visible;
            grdOverlay.Visibility = Visibility.Collapsed;
            dynamic user = App.Current.Properties["User"];
            dynamic dashboardContext = new System.Dynamic.ExpandoObject();
            dashboardContext.WelcomeFull = "Bienvenido, " + user.firstname + " " + user.lastname;
            txbWelcomeUser.DataContext = dashboardContext;
            int i = 1, j = 1;
            foreach (var item in user.userprofile.privileges)
            {
                Button grdMenuOption1 = new Button() { Background = new SolidColorBrush(Color.FromRgb(16, 53, 79)) };
                grdMenuOption1.Click += new RoutedEventHandler(addMenuViews);
                grdMenuOption1.Content = item.views.description;
                grdMenu.Children.Add(grdMenuOption1);
                Grid.SetRow(grdMenuOption1, i);
                Grid.SetColumn(grdMenuOption1, j);
                Grid.SetColumnSpan(grdMenuOption1, 2);
                Grid.SetRowSpan(grdMenuOption1, 2);
                if (j == 7)
                {
                    j = 1;
                    i += 3;
                }
                else
                {
                    j += 3;

                }
            }


        }
        void addMenuViews(object sender, RoutedEventArgs e)
        {
            grdOverlay.Children.Clear();
            string str = ((Button)sender).Content.ToString().ToLower();
            dynamic Privilege = GetPrivilege("Userprofile");
            if (str.CompareTo("configuration") == 0)
            {
                Configuration cng = new Configuration();
                grdOverlay.Children.Add(cng);

            }
            else if (str.CompareTo("users") == 0)
            {
                dynamic gp = GetPrivilege("Users");
                Users cng = new Users(gp, profile_id);
                grdOverlay.Children.Add(cng);
            }
            else if (str.CompareTo("userprofile") == 0)
            {
                
                UserProfile up = new UserProfile(Privilege, profile_id);
                grdOverlay.Children.Add(up);
            }
            else if (str.CompareTo("privilege") == 0)
            {
                Privileges up = new Privileges(Privilege,profile_id);
                grdOverlay.Children.Add(up);
            }
            else if (str.CompareTo("inventory") == 0)
            {
                grdOverlay.Children.Clear();
                /*Configuration cng = new Configuration();
                grdOverlay.Children.Add(cng);
                grdMenu.Visibility = Visibility.Collapsed;
                grdOverlay.Visibility = Visibility.Visible;*/
            }
            if (str.CompareTo("parameter") == 0)
            {
                grdOverlay.Children.Clear();
                /*Configuration cng = new Configuration();
                grdOverlay.Children.Add(cng);
                grdMenu.Visibility = Visibility.Collapsed;
                grdOverlay.Visibility = Visibility.Visible;*/
            }
            grdMenu.Visibility = Visibility.Collapsed;
            grdOverlay.Visibility = Visibility.Visible;

        }
        private dynamic GetPrivilege(String description)
        {
            dynamic user = App.Current.Properties["User"];
            profile_id = (int)user.user_profile_id;
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
