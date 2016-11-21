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
    /// Lógica de interacción para Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        public dynamic Privilege { get; set; }
        ServiceRequest sr = new ServiceRequest();
        public int id { get; set; }

        public Customers(dynamic _Privilege)
        {
            InitializeComponent();
            Privilege = _Privilege;
            LoadList();
        }

        private void LoadList()
        {
            dynamic list = sr.GET("/api/customers");
            listView.ItemsSource = list.customers;
            GridList.Visibility = Visibility.Visible;
            GridForm.Visibility = Visibility.Hidden;
            id = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
