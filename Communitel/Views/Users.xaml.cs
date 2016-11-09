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
using Communitel.Models;
using Communitel.helpers;
using System.Configuration;

namespace Communitel.Views
{

    public partial class Users : UserControl
    {
        public dynamic Privilege { get; set; }
        public dynamic ModelUser { get; set; }
        public int IdUser { get; set; }
        ServiceRequest sr = new ServiceRequest();
        public Users(dynamic _Privilege, int profile)
        {
            Privilege = _Privilege;
            InitializeComponent();

            dynamic list = sr.GET("/api/users");
            listView.ItemsSource = list.users;
            GridUsers.Visibility = Visibility.Visible;
            GridUser.Visibility = Visibility.Hidden;

            btnCreate.IsEnabled = (bool)Privilege.create;
            btnUpdate.IsEnabled = (bool)Privilege.update;
            btnDelete.IsEnabled = (bool)Privilege.delete;

            ComboboxItem item = new ComboboxItem();


            switch (profile)
            {
                case 1:
                    
                    comboBox.Items.Add(new ComboboxItem() { Text = "Super Admin", Value=1 });
                    comboBox.Items.Add(new ComboboxItem() { Text = "Admin", Value = 2 });
                    comboBox.Items.Add(new ComboboxItem() { Text = "Employee", Value = 3 });
                    break;
                case 2:
                    comboBox.Items.Add(new ComboboxItem() { Text = "Admin", Value = 2 });
                    comboBox.Items.Add(new ComboboxItem() { Text = "Employee", Value = 3 });
                    break;
                case 3:
                    comboBox.Items.Add(new ComboboxItem() { Text = "Employee", Value = 3 });
                    break;
            }


            labelValidPass.Content = "";
            labelValidPass.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GridUsers.Visibility = Visibility.Hidden;
            GridUser.Visibility = Visibility.Visible;
            btnCreate.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            txtPass1.IsEnabled = true;
            txtPass2.IsEnabled = true;
            txtUsername.IsEnabled = true;
            ModelUser = new System.Dynamic.ExpandoObject();
            ModelUser.user = new System.Dynamic.ExpandoObject();
            ModelUser.user.firstname = "";
            ModelUser.user.lastname = "";
            ModelUser.user.username = "";
            stFormUser.DataContext = ModelUser.user;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GridUsers.Visibility = Visibility.Visible;
            GridUser.Visibility = Visibility.Hidden;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.Items.Count > 0)
            {

                if (listView.SelectedItems.Count > 0)
                {
                    IdUser = ((dynamic)listView.SelectedItems[0]).id;
                    ModelUser = sr.GET("/api/users/" + IdUser);
                    stFormUser.DataContext = ModelUser.user;
                    GridUsers.Visibility = Visibility.Hidden;
                    GridUser.Visibility = Visibility.Visible;
                    btnCreate.IsEnabled = false;
                    btnUpdate.IsEnabled = true;
                    btnDelete.IsEnabled = true;
                    txtUsername.IsEnabled = false;
                    txtPass1.IsEnabled = false;
                    txtPass2.IsEnabled = false;
                }
            }

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            labelValidPass.Visibility = Visibility.Hidden;
            labelValidPass.Content = "";
            if (txtPass1.Password == txtPass2.Password)
            {
                ModelUser.user.password = txtPass1.Password;
                ModelUser.user.user_profile_id = comboBox.SelectedIndex+1;

                string json = "firstname=" + ModelUser.user.firstname + "&lastname=" + ModelUser.user.lastname + "&username=" + ModelUser.user.username + "&password=" + ModelUser.user.password + "&email=" + ModelUser.user.email + "&user_profile_id=" + ModelUser.user.user_profile_id;

                dynamic obj = sr.POST("/api/users", json);
                IdUser = obj.id;
                if (IdUser > 0)
                {
                    dynamic list = sr.GET("/api/users");
                    listView.ItemsSource = list.users;
                    GridUsers.Visibility = Visibility.Visible;
                    GridUser.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                labelValidPass.Visibility = Visibility.Visible;
                labelValidPass.Content = "Passwords do not match";
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            ModelUser.user.user_profile_id = comboBox.SelectedIndex +1;

            string json = "firstname=" + ModelUser.user.firstname + "&lastname=" + ModelUser.user.lastname + "&username=" + ModelUser.user.username + "&email=" + ModelUser.user.email + "&user_profile_id=" + ModelUser.user.user_profile_id;

            dynamic obj = sr.PUT("/api/users/" + ModelUser.user.id, json);
            IdUser = obj.id;
            if (IdUser > 0)
            {
                dynamic list = sr.GET("/api/users");
                listView.ItemsSource = list.users;
                GridUsers.Visibility = Visibility.Visible;
                GridUser.Visibility = Visibility.Hidden;
            }

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
