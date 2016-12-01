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
    /// Interaction logic for PasswordField.xaml
    /// </summary>
    public partial class PasswordField : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public PasswordField()
        {
            InitializeComponent();
        }
        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            
        }
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
      "Password", typeof(String), typeof(TextField), new FrameworkPropertyMetadata(
            null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Password
        {
            get
            {
                return this.txtText.Password;
            }

            set
            {
                if (value != this.txtText.Password)
                {
                    this.txtText.Password = value;
                    NotifyPropertyChanged();
                }
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
    }
}
