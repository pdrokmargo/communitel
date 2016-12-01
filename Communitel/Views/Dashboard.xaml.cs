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
using Communitel.CustomControls;

namespace Communitel.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public ShowMessage Message { get; set; }
         
        public int user_profile_id { get; set; }
        public int idAuth { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            Login login = new Login();
            grdOverlay.Children.Add(login);
            grdMenu.Visibility = Visibility.Collapsed;
            grdTop.Visibility = Visibility.Collapsed;
            grdRight.Visibility = Visibility.Collapsed;

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
            grdRight.Visibility = Visibility.Visible;
            dynamic user = App.Current.Properties["User"];
            idAuth = (int)user.id;
            dynamic dashboardContext = new System.Dynamic.ExpandoObject(); 
            dashboardContext.WelcomeFull = "Bienvenido, " + user.firstname+ " " + user.lastname;
            //txbWelcomeUser.DataContext = dashboardContext;
            Boolean isFirstTime = false;
            foreach (var item in user.userprofile.privileges)
            {
                //Loading resource disctionary
                var rd = new ResourceDictionary();
                rd.Source = new Uri("pack://application:,,,/styles.xaml");

               //We need to add Profile tile and Dashboard Option respectively before to start add options directly from service.
                if (!isFirstTime) //Add default tiles before available options.
                {
                    //Profile Tile
                    Image imgProfile = new Image();
                    imgProfile.Source = new BitmapImage(new Uri("pack://application:,,,/media/img/profile.png"));
                    imgProfile.Height = 80;
                    imgProfile.Width = 80;
                    TextBlock txbUserProfile = new TextBlock { Text = user.userprofile.description, Foreground = new SolidColorBrush(Color.FromRgb(176, 190, 197)) };
                    TextBlock txbName = new TextBlock { Text = user.firstname + " " + user.lastname, Foreground = new SolidColorBrush(Colors.White) };
                    StackPanel stackPnlProfile = new StackPanel { Margin = new Thickness(20, 20, 20, 20) };
                    stackPnlProfile.Children.Add(imgProfile);
                    stackPnlProfile.Children.Add(txbName);
                    stackPnlProfile.Children.Add(txbUserProfile);

                    //Dashboard Option
                    Image imgDashboard = new Image();
                    imgDashboard.Source = new BitmapImage(new Uri("pack://application:,,,/media/icons/ic_dashboard.png"));
                    imgDashboard.Height = 24;
                    imgDashboard.Width = 24;
                    TextBlock txbDashboardLabel = new TextBlock { Text = "Dashboard"};
                    StackPanel stackPnlDashboard = new StackPanel { Margin = new Thickness(5, 5, 5, 5) };
                    stackPnlDashboard.Children.Add(imgDashboard);
                    stackPnlDashboard.Children.Add(txbDashboardLabel);
                    Button btnDashboard = new Button { Tag = "dashboard", Content = stackPnlDashboard };

                    
                    btnDashboard.Style = rd["MenuButtonStyle"] as Style;
                    btnDashboard.Click += new RoutedEventHandler(addMenuViews);

                    grdMenu.Children.Add(stackPnlProfile);
                    grdMenu.Children.Add(btnDashboard);

                    isFirstTime = !isFirstTime;
                }
                //This for generic options from database.
                Image imgOption = new Image();
                imgOption.Source = new BitmapImage(new Uri("pack://application:,,,/media/icons/" + item.views.icon));
                imgOption.Height = 24;
                imgOption.Width = 24;
                TextBlock txbOptionLabel = new TextBlock { Text = item.views.description };
                StackPanel stackPnlOption = new StackPanel { Margin = new Thickness(5, 5, 5, 5) };
                stackPnlOption.Children.Add(imgOption);
                stackPnlOption.Children.Add(txbOptionLabel);
                Button btnOption = new Button { Tag = item.views.description.ToString().ToLower(), Content = stackPnlOption };
                btnOption.Style = rd["MenuButtonStyle"] as Style;
                btnOption.Click += new RoutedEventHandler(addMenuViews);

                grdMenu.Children.Add(btnOption);
            }


        }
        void addMenuViews(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag.ToString().CompareTo("configuration") == 0)
            {
                grdContent.Children.Clear();
                Configuration cng = new Configuration();
                cng.DashboardContainer = this;
                grdContent.Children.Add(cng);
                grdContent.Visibility = Visibility.Visible;
            }
            else if (((Button)sender).Tag.ToString().CompareTo("ubsers") == 0)
            {
                grdContent.Children.Clear();
                dynamic gp = GetPrivilege("Users");
                Users cng = new Users(gp, user_profile_id,idAuth);
                grdContent.Children.Add(cng);
                //grdMenu.Visibility = Visibility.Collapsed;
                grdContent.Visibility = Visibility.Visible;
            }
            else if (((Button)sender).Tag.ToString().CompareTo("catalog products") == 0)
            {
                grdContent.Children.Clear();
                Products pdr = new Products();
                pdr.DashboardContainer = this;
                grdContent.Children.Add(pdr);
                grdContent.Visibility = Visibility.Visible;
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
        public void popupMessage(String Title, String Message)
        {
            ShowMessage msg = new ShowMessage { Title = Title, Message = Message, Margin = new Thickness(20, 20, 20, 20), DashboardContainer = this };
            grdOverlay.Children.Add(msg);
            grdOverlay.Visibility = Visibility.Visible;
            grdRight.IsEnabled = false;
        }
        public void runMessage(String Title, String Message)
        {
            
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
