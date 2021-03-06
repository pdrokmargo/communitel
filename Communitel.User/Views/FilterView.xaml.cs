﻿using Communitel.User.ViewModels;
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

namespace Communitel.User.Views
{
    /// <summary>
    /// Lógica de interacción para FilterView.xaml
    /// </summary>
    [Export("FilterUserView")]
    public partial class FilterView : UserControl
    {
        public FilterView()
        {
            InitializeComponent();
        }

        [Import]
        public UserViewModel UserViewModel { get { return DataContext as UserViewModel; } set { DataContext = value; } }

    }
}
