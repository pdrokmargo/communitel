using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for TextField.xaml
    /// </summary>
    public partial class TextField : UserControl
    {
        DataType _datatype;
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
        public string Text
        {
            get
            {
                return this.txtText.Text.ToUpper();
            }

            set
            {
                if (value != this.txtText.Text)
                {
                    this.txtText.Text = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
      "Text", typeof(String), typeof(TextField), new FrameworkPropertyMetadata(
            null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public DataType DataType
        {
            get
            {
                return this._datatype;
            }

            set
            {
                if (value != this._datatype)
                {
                    this._datatype = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public TextField()
        {
            InitializeComponent();
        }
        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if(DataType == DataType.Numeric)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }  
        }
    }
    public enum DataType
    {
        Text,
        Numeric

    }
}
