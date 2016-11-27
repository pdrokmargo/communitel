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
                    t1.Text = user.firstname + " " + user.lastname;
                    t1.Foreground = new SolidColorBrush(Colors.White);
                    t1.Text = user.userprofile.description;
                    t1.Foreground = new SolidColorBrush(Color.FromRgb(176, 190, 197));
                    stackPnl.Children.Add(img);
                    stackPnl.Children.Add(t1);

                    Button btn2 = new Button() { };
                    StackPanel stackPnl2 = new StackPanel();
                    stackPnl2.Margin = new Thickness(10);
                    stackPnl2.Orientation = Orientation.Vertical;
                    btn2.Content = stackPnl2;
                    btn2.Style = rd["MenuButtonStyle"] as Style;
                    btn2.Click += new RoutedEventHandler(addMenuViews);
                    Image img2 = new Image();
                    img2.Height = 24;
                    img2.Width = 24;
                    img2.Source = new BitmapImage(new Uri("pack://application:,,,/media/icons/ic_dashboard.png"));
                    TextBlock t2 = new TextBlock();
                    t2.Text = "Dashboard";
                    btn2.Tag = "dashboard";
                    stackPnl2.Children.Add(img2);
                    stackPnl2.Children.Add(t2);

                    Button btn3 = new Button() { };
                    StackPanel stackPnl3 = new StackPanel();
                    stackPnl3.Margin = new Thickness(10);
                    stackPnl3.Orientation = Orientation.Vertical;
                    btn3.Content = stackPnl3;
                    Image img3 = new Image();
                    img3.Height = 24;
                    img3.Width = 24;
                    img3.Source = new BitmapImage(new Uri("pack://application:,,,/media/icons/" + item.views.icon));
                    TextBlock t3 = new TextBlock();
                    t3.Text = item.views.description;
                    btn3.Style = rd["MenuButtonStyle"] as Style;
                    btn3.Tag = item.views.description.ToString().ToLower();

                    btn3.Click += new RoutedEventHandler(addMenuViews);
                    stackPnl3.Children.Add(img3);
                    stackPnl3.Children.Add(t3);

                    grdMenu.Children.Add(stackPnl);
                    grdMenu.Children.Add(btn2);
                    grdMenu.Children.Add(btn3);
                    
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
               
                if(i >1)
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
                //txbWindowTitle.Text = "Configuration";
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
                Users cng = new Users(gp, user_profile_id);
                grdContent.Children.Add(cng);
                //grdMenu.Visibility = Visibility.Collapsed;
                grdContent.Visibility = Visibility.Visible;
            }
            else if (((Button)sender).Content.ToString().ToLower().CompareTo("check in") == 0)
            {
                grdContent.Children.Clear();
            }
            if (((Button)sender).Content.ToString().ToLower().CompareTo("catalog products") == 0)
            {
                grdContent.Children.Clear();
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
