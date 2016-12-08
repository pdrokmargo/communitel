using Communitel.Common.Behaviour;
using Communitel.Common.Models;
using Communitel.Common.ViewModels;
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

namespace Communitel.Common.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.WorkSpaceRegion)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    [ViewSortHint("1")]
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        [Import]
        public LoginViewModel LoginViewModel { get { return DataContext as LoginViewModel; } set { DataContext = value; } }
    }
}
