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
using Communitel.helpers;
using Newtonsoft.Json;

namespace Communitel.Views
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        dynamic Product;
        public Dashboard DashboardContainer { get; set; }
        ServiceRequest sr = new ServiceRequest();
        Boolean isDirty = false;
        public Products()
        {
            InitializeComponent();
            GetAllUsers();
           /* CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = Filter;*/
        }
        /*private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                return true;
            else
                return ((item as dynamic).name.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            
                
        }*/

        private void GetAllUsers()
        {
            dynamic products = sr.GET("/api/products");
            listView.ItemsSource = products.products;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            txbTitle.Text = "Products Catalog - Add new Product";
            grdProductsForm.Visibility = Visibility.Visible;
            grdProductsList.Visibility = Visibility.Collapsed;
            Product = new System.Dynamic.ExpandoObject();
            btnSave.Content = "Save";
            grdProductsForm.DataContext = Product;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (isDirty)
            {
                dynamic products = sr.GET("/api/products");
                listView.ItemsSource = products.products;
                isDirty = !isDirty;
            }
            txbTitle.Text = "Products Catalog";
            grdProductsForm.Visibility = Visibility.Collapsed;
            grdProductsList.Visibility = Visibility.Visible;
            
        }
        Boolean ValidateData(dynamic obj)
        {
            foreach (var item in obj)
            {
                if (item.Value.ToString().Trim() == "")
                {
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData(Product))
            {
                string json = JsonConvert.SerializeObject(Product);
                isDirty = !isDirty;
                if (btnSave.Content.ToString().ToLower() == "save")
                {
                    dynamic obj = sr.POST("/api/products", json);
                    btnSave.Content = "Update";
                    DashboardContainer.popupMessage("Products", "A new product has been created!");
                }
                else
                {
                    dynamic obj = sr.PUT("/api/products/" + Product.id, json);
                    DashboardContainer.popupMessage("Products", "The product has been updated!");
                }
            }
            else
            {
                DashboardContainer.popupMessage("Missing Information", "It seems some fields are empty. Please check them.");
            }
            
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                dynamic id = ((dynamic)listView.SelectedItem).id;
                //listView.SelectedItem = null;
                Product = sr.GET("/api/products/" + id).Product;
                txbTitle.Text = "Products Catalog - Add new Product";
                grdProductsForm.Visibility = Visibility.Visible;
                grdProductsList.Visibility = Visibility.Collapsed;
                btnSave.Content = "Update";
                grdProductsForm.DataContext = Product;
            }
        }
    }
}
