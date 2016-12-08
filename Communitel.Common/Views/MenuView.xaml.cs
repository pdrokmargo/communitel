using Communitel.Common.ViewModels;
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
    /// Lógica de interacción para MenuView.xaml
    /// </summary>
    [Export("MenuView")]
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        }

        [Import]
        public MenuViewModel MenuViewModel { get { return DataContext as MenuViewModel; } set { DataContext = value; } }
    }
}
