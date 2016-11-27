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
        public int idAuth { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            Login login = new Login();
            grdOverlay.Children.Add(login);
            grdMenu.Visibility = Visibility.Collapsed;
            grdTop.Visibility = Visibility.Collapsed;

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
            grdTop.Visibility = Visibility.Visible;
            dynamic user = App.Current.Properties["User"];
            idAuth = (int)user.id;
            dynamic dashboardContext = new System.Dynamic.ExpandoObject(); 
            dashboardContext.WelcomeFull = "Bienvenido, " + user.firstname+ " " + user.lastname;
            //txbWelcomeUser.DataContext = dashboardContext;
            int i = 1;
            foreach (var item in user.userprofile.privileges)
            {
                Image img = new Image();
                img.Height = 24;
                img.Width = 24;
                StackPanel stackPnl = new StackPanel();
                stackPnl.Margin = new Thickness(10);
                stackPnl.Orientation = Orientation.Vertical;
                Button btn = new Button() { /*Background = new SolidColorBrush(Color.FromRgb(55, 71, 79))*/ };
                var rd = new ResourceDictionary();
                rd.Source = new Uri("pack://application:,,,/styles.xaml");
                btn.Style = rd["MenuButtonStyle"] as Style;
                btn.Click += new RoutedEventHandler(addMenuViews);
                TextBlock t = new TextBlock();
                Grid.SetRow(btn, i);
                Grid.SetColumn(btn, 0);
                Grid.SetColumnSpan(btn, 12);
                Grid.SetRowSpan(btn, 1);
                if (i == 1)
                {
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/media/img/profile.png"));
                    img.Height = 80;
                    img.Width = 80;
                    TextBlock t1 = new TextBlock();
                    t.Text = user.firstname + " " + user.lastname;
                    t.Foreground = new SolidColorBrush(Colors.White);
                    t1.Text = user.userprofile.description;
                    t1.Foreground = new SolidColorBrush(Color.FromRgb(176, 190, 197));
                    stackPnl.Children.Add(img);
                    stackPnl.Children.Add(t);
                    stackPnl.Children.Add(t1);
                }
                else if (i == 2)
                {
                    btn.Content = stackPnl;
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/media/icons/ic_dashboard.png"));
                    t.Text = "Dashboard";
                    btn.Tag = "dashboard";
                    stackPnl.Children.Add(img);
                    stackPnl.Children.Add(t);
                }
                else
                {
                    btn.Content = stackPnl;
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/media/icons/" + item.views.icon));
                    t.Text = item.views.description;
                    btn.Tag = item.views.description.ToString().ToLower();
                    stackPnl.Children.Add(img);
                    stackPnl.Children.Add(t);
                }
               
                if(i == 1)
                {
                    grdMenu.Children.Add(stackPnl);
                }
                else
                { 
                    grdMenu.Children.Add(btn);
                }
                
                
                i++;
            }


        }
        void addMenuViews(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag.ToString().CompareTo("configuration") == 0)
            {
                txbWindowTitle.Text = "Configuration";
                grdContent.Children.Clear();
                Configuration cng = new Configuration();
                grdContent.Children.Add(cng);
                //grdMenu.Visibility = Visibility.Collapsed;
                grdContent.Visibility = Visibility.Visible;
            }
            else if (((Button)sender).Tag.ToString().CompareTo("users") == 0)
            {
                grdContent.Children.Clear();
                dynamic gp = GetPrivilege("Users");
                Users cng = new Users(gp, user_profile_id,idAuth);
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
