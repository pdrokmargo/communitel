using Communitel.User.ViewModels;
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

namespace Communitel.User.Views
{
    /// <summary>
    /// Lógica de interacción para SearchUserView.xaml
    /// </summary>
    [Export("SearchUserView")]
    public partial class SearchUserView : UserControl
    {
        private ListSortDirection _direction = ListSortDirection.Ascending;
        public SearchUserView()
        {
            InitializeComponent();
        }

        [Import]
        public UserViewModel UserViewModel { get { return DataContext as UserViewModel; } set { DataContext = value; } }

        private async void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            _direction = _direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;

            UserViewModel.Reverse = _direction == ListSortDirection.Ascending ? 1 : 0;
            UserViewModel.SortBy = e.Column.SortMemberPath;

            await UserViewModel.GetAll();

            e.Column.SortDirection = _direction;
        }
    }
}
