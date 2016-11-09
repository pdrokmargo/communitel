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
using Communitel.ViewModel;
namespace Communitel.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for GridMenu.xaml
    /// </summary>
    public partial class GridMenu : UserControl
    {
        public GridMenu()
        {
            InitializeComponent();
        }

        public void createMenu()
        {
            OptionMenuViewModel opv = new OptionMenuViewModel();
            grdMenu.DataContext = opv.Menu;


            Label lbl = new Label();

        }
    }
}
