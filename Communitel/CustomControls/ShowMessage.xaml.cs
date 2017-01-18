using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Communitel.Views;

namespace Communitel.CustomControls
{
    /// <summary>
    /// Interaction logic for ShowMessage.xaml
    /// </summary>
    public partial class ShowMessage : UserControl, INotifyPropertyChanged
    {
        public Dashboard DashboardContainer { get; set; }
        public Grid OverlayContainer { get; set; }
        public Grid RightContainer { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Title
        {
            get
            {
                return this.txbTitle.Text;
            }

            set
            {
                if (value != this.txbTitle.Text)
                {
                    this.txbTitle.Text = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Message
        {
            get
            {
                return this.txbMessage.Text;
            }

            set
            {
                if (value != this.txbMessage.Text)
                {
                    this.txbMessage.Text = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ShowMessage()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DashboardContainer.closeCurrent();
            DashboardContainer.grdOverlay.Visibility = Visibility.Collapsed;
            DashboardContainer.grdRight.IsEnabled = true;
        }
    }
}
