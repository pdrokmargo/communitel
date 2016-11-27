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
using System.Text.RegularExpressions;

namespace Communitel.Views
{

    public partial class Users : UserControl
    {
        public dynamic Privilege { get; set; }
        public dynamic ModelUser { get; set; }
        public int IdUser { get; set; }
        public int idAuth { get; set; }
        public int profile { get; set; }
        ServiceRequest sr = new ServiceRequest();
        string sMessageBoxText = "";
        string sCaption = "";


        public Users(dynamic _Privilege, int _profile, int _idAuth)
        {
            Privilege = _Privilege;
            profile = _profile;
            idAuth = _idAuth;
            InitializeComponent();
            LoadGridUsers();
            LoadCombo();
            labelValidPass.Content = "";
            labelValidPass.Visibility = Visibility.Collapsed;
        }

        private void LoadGridUsers()
        {
            dynamic list = sr.GET("/api/users");
            listView.ItemsSource = list.users;


            GridUsers.Visibility = Visibility.Visible;
            GridUser.Visibility = Visibility.Hidden;
            IdUser = 0;
        }
        private void LoadCombo()
        {
            var com = sr.GET("/api/userprofile");
            com = com.userprofile;
            /*
            for (int i = 0; i < com.Count; i++)
            {
                if ((int)com[i].id <= profile)
                {
                    com.Remove(com[i]);
                }
            }*/

            comboBox.ItemsSource = com;
            comboBox.DisplayMemberPath = "description";
            comboBox.SelectedValuePath = "id";
        }

        //NEW USER
        private void button_Click(object sender, RoutedEventArgs e)
        {
            GridUsers.Visibility = Visibility.Hidden;
            GridUser.Visibility = Visibility.Visible;
            if ((bool)Privilege.create)
            {
                btnCreate.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }

            txtPass1.IsEnabled = true;
            txtPass2.IsEnabled = true;
            txtUsername.IsEnabled = true;
            btn_reset.Visibility = Visibility.Hidden;
            btn_reset_save.Visibility = Visibility.Hidden;
            btn_reset_cancel.Visibility = Visibility.Hidden;

            ModelUser = new System.Dynamic.ExpandoObject();
            ModelUser.user = new System.Dynamic.ExpandoObject();
            ModelUser.user.firstname = "";
            ModelUser.user.lastname = "";
            ModelUser.user.username = "";
            ModelUser.user.user_profile_id = 0;
            GridUser.DataContext = ModelUser.user;
        }
        //to back
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GridUsers.Visibility = Visibility.Visible;
            GridUser.Visibility = Visibility.Hidden;
        }
        //event list
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.Items.Count > 0)
            {

                if (listView.SelectedItems.Count > 0)
                {
                    IdUser = ((dynamic)listView.SelectedItems[0]).id;
                    ModelUser = sr.GET("/api/users/" + IdUser);
                    txtPass1.Password = "";
                    txtPass2.Password = "";
                    GridUser.DataContext = ModelUser.user;
                    comboBox.SelectedValue = ModelUser.user.userprofile.id;
                    GridUsers.Visibility = Visibility.Hidden;
                    GridUser.Visibility = Visibility.Visible;

                    btnCreate.Visibility = Visibility.Collapsed;
                    btnUpdate.Visibility = Visibility.Visible;
                    btnDelete.Visibility = Visibility.Visible;

                    txtUsername.IsEnabled = false;
                    txtPass1.IsEnabled = false;
                    txtPass2.IsEnabled = false;
                    btn_reset.Visibility = Visibility.Visible;
                    btn_reset_save.Visibility = Visibility.Collapsed;
                    btn_reset_cancel.Visibility = Visibility.Collapsed;

                }
            }

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            labelValidPass.Visibility = Visibility.Collapsed;
            labelValidPass.Content = "";
            if (txtPass1.Password == txtPass2.Password)
            {
                ModelUser.user.password = txtPass1.Password;
                ModelUser.user.user_profile_id = comboBox.SelectedIndex + 1;

                string json = "firstname=" + ModelUser.user.firstname + "&lastname=" + ModelUser.user.lastname + "&username=" + ModelUser.user.username + "&password=" + ModelUser.user.password + "&email=" + ModelUser.user.email + "&user_profile_id=" + ModelUser.user.user_profile_id;

                dynamic obj = sr.POST("/api/users", json);
                IdUser = obj.id;
                if (IdUser > 0)
                {
                    dynamic list = sr.GET("/api/users");
                    sMessageBoxText = "User save";
                    sCaption = "Success";
                    MessageBoxButton btnMessageBox = MessageBoxButton.OK;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Information;
                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                    LoadGridUsers();
                }
            }
            else
            {
                labelValidPass.Visibility = Visibility.Visible;
                labelValidPass.Content = "Passwords do not match";
                txtPass1.Password = "";
                txtPass2.Password = "";
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            ModelUser.user.user_profile_id = comboBox.SelectedIndex + 1;

            string json = "firstname=" + ModelUser.user.firstname + "&lastname=" + ModelUser.user.lastname + "&username=" + ModelUser.user.username + "&email=" + ModelUser.user.email + "&user_profile_id=" + ModelUser.user.user_profile_id;

            dynamic obj = sr.PUT("/api/users/" + ModelUser.user.id, json);
            IdUser = obj.id;
            if (IdUser > 0)
            {
                sMessageBoxText = "User update";
                sCaption = "Success";
                MessageBoxButton btnMessageBox = MessageBoxButton.OK;
                MessageBoxImage icnMessageBox = MessageBoxImage.Information;
                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                LoadGridUsers();

            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            sMessageBoxText = "Do you want to continue?";
            sCaption = "Delete";
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    dynamic rs = sr.DELETE("/api/users/" + IdUser);
                    sMessageBoxText = "User delete";
                    sCaption = "Success";
                    btnMessageBox = MessageBoxButton.OK;
                    icnMessageBox = MessageBoxImage.Information;
                    rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                    LoadGridUsers();
                    break;
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

        private void btn_reset_save_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass1.Password.Trim().Length > 0 && txtPass2.Password.Trim().Length > 0)
            {
                if (txtPass1.Password == txtPass2.Password)
                {
                    string json = "newPass=" + txtPass1.Password + "&id=" + IdUser + "&idAuth=" + idAuth;
                    dynamic obj = sr.POST("/api/resetPassword", json);

                    sMessageBoxText = "Success";
                    sCaption = "Password reset";
                    MessageBoxButton btnMessageBox = MessageBoxButton.OK;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                    est_save_cancel();
                    labelValidPass.Content = "";
                    labelValidPass.Visibility = Visibility.Collapsed;

                }
                else
                {
                    labelValidPass.Content = "The information entered is not the same";
                    labelValidPass.Visibility = Visibility.Visible;
                }
            }
            else
            {
                labelValidPass.Content = "Password and Reset password are required";
                labelValidPass.Visibility = Visibility.Visible;
            }

        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            btn_reset.Visibility = Visibility.Collapsed;
            btn_reset_save.Visibility = Visibility.Visible;
            btn_reset_cancel.Visibility = Visibility.Visible;
            txtPass1.IsEnabled = true;
            txtPass2.IsEnabled = true;

        }

        private void btn_reset_cancel_Click(object sender, RoutedEventArgs e)
        {
            est_save_cancel();
        }

        private void est_save_cancel()
        {
            btn_reset.Visibility = Visibility.Visible;
            btn_reset_save.Visibility = Visibility.Collapsed;
            btn_reset_cancel.Visibility = Visibility.Collapsed;
            txtPass1.IsEnabled = false;
            txtPass2.IsEnabled = false;
            txtPass1.Password = "";
            txtPass2.Password = "";
        }

        private void validateUsername(object sender, KeyEventArgs e)
        {

        }
    }
}
