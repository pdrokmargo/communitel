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

namespace Communitel.Views.Views
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            view_user.Visibility = System.Windows.Visibility.Hidden;
        }

        private void showUser() {
            view_user.Visibility = System.Windows.Visibility.Visible;
            view_users.Visibility = System.Windows.Visibility.Hidden;
        }
        private void showUsers() {
            view_users.Visibility = System.Windows.Visibility.Visible;
            view_user.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
