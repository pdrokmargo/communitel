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

namespace Communitel.Views
{
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : UserControl
    {
        public Configuration()
        {
            InitializeComponent();
            ServiceRequest svc = new ServiceRequest();
            dynamic obj = svc.GET("/api/config", (string)App.Current.Properties["Token"]);
            grd.DataContext = obj;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dsh = ((Dashboard)((Grid)((Grid)this.Parent).Parent).Parent);
            dsh.closeCurrent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequest svc = new ServiceRequest();

            string parsedContent = "tax_percent=" + txtTax.Text + "&expiry_days=" + txtExpiryDays.Text + "&red_price=" + txtRedPrice.Text + "&yellow_price=" + txtYellowPrice.Text + "&green_price=" + txtGreenPrice.Text;
            dynamic obj = svc.PUT("/api/config/change", (string)App.Current.Properties["Token"], parsedContent);

        }
    }
}
