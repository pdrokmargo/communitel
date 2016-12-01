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

namespace Communitel.CustomControls
{
    /// <summary>
    /// Interaction logic for AggregatedObject.xaml
    /// </summary>
    public partial class AggregatedObject : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Label
        {
            get
            {
                return this.txbLabel.Text.ToUpper();
            }

            set
            {
                if (value != this.txbLabel.Text)
                {
                    this.txbLabel.Text = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public AggregatedObject()
        {
            InitializeComponent();
        }
    }
}
