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
    /// Lógica de interacción para Checkin.xaml
    /// </summary>
    public partial class Checkin_bag : UserControl
    {
        public dynamic Privilege { get; set; }
        public dynamic Privilege_customers { get; set; }
        public int Profile_id { get; set; }
        public int poss { get; set; }
        public int totalTabs { get; set; }
        Customers viewCustomers;


        public Checkin_bag(dynamic _Privilege, dynamic _Privilege_customers, int _Profile_id)
        {
            InitializeComponent();
            Privilege = _Privilege;
            Profile_id = _Profile_id;
            btnprev.IsEnabled = false;
            poss = 1;
            totalTabs = 2;
            viewCustomers = new Customers(_Privilege_customers);
            GridTab1_customers.Children.Add(viewCustomers);
            LoadTabs();

        }
        private void LoadTabs()
        {
            int aux = 1;
            foreach (object item in GridContainer.Children)
            {
                Grid g = item as Grid;
                if (aux != poss)
                {
                    g.Visibility = Visibility.Collapsed;
                }
                if (aux == poss)
                {
                    g.Visibility = Visibility.Visible;
                }
                aux++;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GridList.Visibility = Visibility.Collapsed;
            GridForm.Visibility = Visibility.Visible;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            GridList.Visibility = Visibility.Visible;
            GridForm.Visibility = Visibility.Collapsed;
        }

        private void btnprev_Click(object sender, RoutedEventArgs e)
        {
            poss--;
            if (poss <= 1)
            {
                poss = 1;
                btnprev.IsEnabled = false;
                btnNext.IsEnabled = true;
            }
            LoadTabs();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            poss++;
            if (poss >= totalTabs)
            {
                poss = totalTabs;
                btnprev.IsEnabled = true;
                btnNext.IsEnabled = false;
            }
            LoadTabs();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            GridTab1_form.Visibility = Visibility.Collapsed;
            GridTab1_customers.Visibility = Visibility.Visible;
            //viewCustomers.newCustomers();
        }
    }
}
