using Communitel.helpers;
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

namespace Communitel.Views
{
    /// <summary>
    /// Lógica de interacción para UserProfile.xaml
    /// </summary>
    public partial class UserProfile : UserControl
    {
        ServiceRequest sr = new ServiceRequest();
        public int id { get; set; }
        public dynamic Privilege { get; set; }
        public int Profile { get; set; }

        public UserProfile(dynamic _Privilege, int _Profile)
        {

            InitializeComponent();
            Privilege = _Privilege;
            Profile = _Profile;
            LoadList();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GridUserProfiles.Visibility = Visibility.Visible;
            GridUserProfile.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GridUserProfiles.Visibility = Visibility.Collapsed;
            GridUserProfile.Visibility = Visibility.Visible;
            btnSave.IsEnabled = true;
            btnUpdate.IsEnabled = false;
        }

        private void LoadList()
        {
            dynamic list = ((dynamic)sr.GET("/api/userprofile")).userprofile;
            listView.ItemsSource = list;
            GridUserProfiles.Visibility = Visibility.Visible;
            GridUserProfile.Visibility = Visibility.Collapsed;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    id = ((dynamic)listView.SelectedItems[0]).id;
                    dynamic d = ((dynamic)sr.GET("/api/userprofile/" + id)).userprofile;
                    stFrom.DataContext = d;
                    GridUserProfiles.Visibility = Visibility.Collapsed;
                    GridUserProfile.Visibility = Visibility.Visible;
                    btnSave.IsEnabled = false;
                    btnUpdate.IsEnabled = true;
                }
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserProfile.Text.Trim().Length > 0)
            {
                string str = txtUserProfile.Text;
                dynamic rs = sr.POST("/api/userprofile", "description=" + str);
                id = rs.id;
                MessageBox.Show("UserProfile Create", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserProfile.Text.Trim().Length > 0)
            {
                string str = txtUserProfile.Text;
                dynamic rs = sr.PUT("/api/userprofile/"+id, "id=" + id + "&description=" + str);
                MessageBox.Show("UserProfile Update", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadList();
            }
        }
    }
}
