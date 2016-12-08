using Communitel.Common.Enums;
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
using System.Windows.Shapes;

namespace Communitel.Common.Views
{
    /// <summary>
    /// Lógica de interacción para MessageBox.xaml
    /// </summary>
    public partial class MessageBoxView : Window
    {
        public MessageBoxView()
        {
            InitializeComponent();
            this.Loaded += MessageBoxView_Loaded;
            this.KeyDown += MessageBoxView_KeyDown;
        }

        private string _Mensaje = string.Empty;
        private string _Text = "Mensaje";
        private MessageBoxButtonsV _MessageBoxButton = MessageBoxButtonsV.Accept;
        private MessageBoxIconV _MessageBoxIcon = MessageBoxIconV.Information;
        private DialogResultV _DialogResult = DialogResultV.Yes;
        private MessageBoxDefaultButtonV _MessageBoxDefaultButton = MessageBoxDefaultButtonV.Button1;

        public string Mensaje { get { return _Mensaje; } set { _Mensaje = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
        public MessageBoxButtonsV MessageBoxButton { get { return _MessageBoxButton; } set { _MessageBoxButton = value; } }
        public MessageBoxIconV MessageBoxIcon { get { return _MessageBoxIcon; } set { _MessageBoxIcon = value; } }
        public DialogResultV DialogResult { get { return _DialogResult; } set { _DialogResult = value; } }
        public MessageBoxDefaultButtonV MessageBoxDefaultButton { get; set; }

        public void MessageBoxView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                //this.Close();
            }
        }

        private void MessageBoxView_Loaded(object sender, RoutedEventArgs e)
        {
            txtmensaje.Text = Mensaje;
            txttext.Text = this.Text;

            CondicionesButton();
        }

        private void CondicionesButton()
        {
            if (this.MessageBoxButton == MessageBoxButtonsV.YesNo)
            {
                btn1.Content = "Yes";
                btn2.Content = "No";
                btn3.Visibility = Visibility.Collapsed;
            }
            else if (this.MessageBoxButton == MessageBoxButtonsV.OkCancel)
            {
                btn1.Content = "Ok";
                btn2.Content = "Cancel";
                btn3.Visibility = Visibility.Collapsed;
            }
            else if (this.MessageBoxButton == MessageBoxButtonsV.Accept)
            {
                btn1.Visibility = Visibility.Collapsed;
                btn2.Visibility = Visibility.Collapsed;
                btn3.Content = "Accept";
                btn3.Focus();
            }
            else if (this.MessageBoxButton == MessageBoxButtonsV.Ok)
            {
                btn1.Visibility = Visibility.Collapsed;
                btn2.Visibility = Visibility.Collapsed;
                btn3.Content = "Ok";
                btn3.Focus();
            }

            if (this.MessageBoxIcon == MessageBoxIconV.Information)
            {
                imginf.Visibility = Visibility.Visible;
            }
            else if (this.MessageBoxIcon == MessageBoxIconV.Question)
            {
                imgquest.Visibility = Visibility.Visible;
            }
            else if (this.MessageBoxIcon == MessageBoxIconV.Warning)
            {
                imgwarn.Visibility = Visibility.Visible;
            }
            else if (this.MessageBoxIcon == MessageBoxIconV.Error)
            {
                imgerror.Visibility = Visibility.Visible;
            }

            if (MessageBoxDefaultButton == MessageBoxDefaultButtonV.Button1)
            {
                btn1.Focus();
            }
            else if (MessageBoxDefaultButton == MessageBoxDefaultButtonV.Button2)
            {
                btn2.Focus();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (btn1.Content.ToString() == "Yes")
            {
                this.DialogResult = DialogResultV.Yes;
            }
            else if (btn1.Content.ToString() == "Ok")
            {
                this.DialogResult = DialogResultV.Ok;
            }
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (btn2.Content.ToString() == "No")
            {
                this.DialogResult = DialogResultV.No;
            }
            else if (btn2.Content.ToString() == "Cancel")
            {
                this.DialogResult = DialogResultV.Cancel;
            }
            this.Close();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
