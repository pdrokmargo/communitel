using Communitel.CheckIn.ViewModels;
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

namespace Communitel.CheckIn.Views
{
    /// <summary>
    /// Lógica de interacción para SearchCheckInView.xaml
    /// </summary>
    [Export("SearchCheckInView")]
    public partial class SearchCheckInView : UserControl
    {
        private ListSortDirection _direction = ListSortDirection.Ascending;
        public SearchCheckInView()
        {
            InitializeComponent();
        }

        [Import]
        public CheckInViewModel CheckInViewModel { get { return DataContext as CheckInViewModel; } set { DataContext = value; } }

        private async void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            try
            {

                _direction = _direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
                
                this.CheckInViewModel.Reverse = _direction == ListSortDirection.Ascending ? 1 : 0;
                this.CheckInViewModel.SortBy = e.Column.SortMemberPath;

                await CheckInViewModel.GetAll();

                e.Column.SortDirection = _direction;
            }
            catch (Exception ex)
            {
                Communitel.Common.Messages.MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

    }
}
