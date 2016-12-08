using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.WPF;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace Communitel.Common.Models
{
    public class Menu : NotifyProperty
    {
        private string _name;
        private FontAwesome.WPF.FontAwesomeIcon _icon;
        private DelegateCommand _command;
        private Visibility _visible= Visibility.Visible;
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }
        public FontAwesome.WPF.FontAwesomeIcon Icon { get { return _icon; } set { _icon = value; NotifyPropertyChanged("Icon"); } }
        public DelegateCommand Command { get; set; }
        public Visibility Visible { get { return _visible; } set { _visible = value; NotifyPropertyChanged("Visible"); } }
    }
}
