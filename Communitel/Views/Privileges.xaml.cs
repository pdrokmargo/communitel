using Communitel.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
    /// Lógica de interacción para Privileges.xaml
    /// </summary>
    public partial class Privileges : UserControl
    {
        public int id { get; set; }
        ServiceRequest sr = new ServiceRequest();
        public dynamic Privilege { get; set; }
        public int Profile_id { get; set; }
        List<ItemPrivileges> list;

        public Privileges(dynamic _Privilege, int _Profile_id)
        {
            InitializeComponent();
            Privilege = _Privilege;
            Profile_id = _Profile_id;
            LoadList();

        }

        private void LoadList()
        {
            listView.ItemsSource = ((dynamic)sr.GET("/api/userprofile")).userprofile;
            GridList.Visibility = Visibility.Visible;
            GridForm.Visibility = Visibility.Collapsed;
            id = 0;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    id = ((dynamic)listView.SelectedItems[0]).id;
                    label.Content = ((dynamic)listView.SelectedItems[0]).description;
                    GridList.Visibility = Visibility.Collapsed;
                    GridForm.Visibility = Visibility.Visible;
                    LoadViewsPrivilege();
                }
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GridList.Visibility = Visibility.Visible;
            GridForm.Visibility = Visibility.Collapsed;
        }

        private void LoadViewsPrivilege()
        {
            dynamic views = ((dynamic)sr.GET("/api/view")).views;
            dynamic AllPrivileges = (((dynamic)sr.GET("/api/userprofile/" + id))).userprofile.privileges;
            list = new List<ItemPrivileges>();

            foreach (var view in views)
            {
                list.Add(new ItemPrivileges { view_id = view.id, view = view.description, create = false, read = false, update = false, delete = false });
            }

            foreach (var x in AllPrivileges)
            {
                foreach (var y in list)
                {
                    if ((int)x.view_id == y.view_id)
                    {
                        y.id = x.id;
                        y.create = (bool)x.create;
                        y.read = (bool)x.read;
                        y.update = (bool)x.update;
                        y.delete = (bool)x.delete;
                    }
                }
            }

            listView1.ItemsSource = list;
        }

        public class ItemPrivileges
        {
            public int id { get; set; }
            public int view_id { get; set; }
            public string view { get; set; }
            public bool create { get; set; }
            public bool read { get; set; }
            public bool update { get; set; }
            public bool delete { get; set; }
        }

        private void chkCreate_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in list)
            {
                item.create = (bool)chkCreate.IsChecked;
            }
            RefreshList();
        }

        private void chkRead_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in list)
            {
                item.read = (bool)chkRead.IsChecked;
            }
            RefreshList();
        }

        private void chkUpdate_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in list)
            {
                item.update = (bool)chkUpdate.IsChecked;
            }
            RefreshList();
        }

        private void chkDelete_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in list)
            {
                item.delete = (bool)chkDelete.IsChecked;
            }
            RefreshList();
        }

        private void RefreshList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(list);
            view.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string s = "user_profile_id =" + Profile_id;
            //string s = "{\"user_profile_id\" : \"" + Profile_id + "\", \"items\" : [";
            /*
            foreach (var item in list)
            {
                s += "{\"id\":\"" + item.id + "\",\"create\":\"" + item.create + "\",\"read\":\"" + item.read + "\",\"update\":\"" + item.update + "\",\"delete\":\"" + item.delete + "\"},";
            }
            s += "]}";*/
            dynamic rs = sr.POST("/api/privileges", s);
        }
    }
}
