using Communitel.Product.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
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

namespace Communitel.Product.Views
{
    /// <summary>
    /// Lógica de interacción para SearchProductView.xaml
    /// </summary>
    [Export("SearchProductView")]
    public partial class SearchProductView : UserControl
    {
        private ListSortDirection _direction = ListSortDirection.Ascending;
        public SearchProductView()
        {
            InitializeComponent();
        }

        [Import]
        public ProductViewModel ProductViewModel { get { return DataContext as ProductViewModel; } set { DataContext = value; } }

        private async void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            try
            {

                _direction = _direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;

                ProductViewModel.Reverse = _direction == ListSortDirection.Ascending ? 1 : 0;
                ProductViewModel.SortBy = e.Column.SortMemberPath;

                await ProductViewModel.GetAll();

                e.Column.SortDirection = _direction;
            }
            catch (Exception ex)
            {
                Communitel.Common.Messages.MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }
    }
}
