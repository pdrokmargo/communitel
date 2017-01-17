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
            this.Loaded += LoginView_Loaded;
        }

        private void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            txt_user.Focusable = true;
        }

        [Import]
        public LoginViewModel LoginViewModel { get { return DataContext as LoginViewModel; } set { DataContext = value; } }

        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key== Key.Enter)
            {
                LoginViewModel.LoginCommand.Execute();
            }           
        }
    }
}
