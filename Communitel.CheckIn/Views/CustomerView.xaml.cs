using Communitel.CheckIn.ViewModels;
using Communitel.Common.Behaviour;
using Communitel.Common.Models;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para CustomerView.xaml
    /// </summary>
    [Export("CustomerView")]
    [ViewExport(RegionName = RegionNames.ContentStep)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("1")]
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        [Import]
        public CheckInViewModel CheckInViewModel { get { return DataContext as CheckInViewModel; } set { DataContext = value; } }
    }
}
