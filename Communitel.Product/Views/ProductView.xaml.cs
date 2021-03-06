﻿using Communitel.Product.ViewModels;
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

namespace Communitel.Product.Views
{
    /// <summary>
    /// Lógica de interacción para ProductView.xaml
    /// </summary>
    [Export("ProductView")]
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }

        [Import]
        public ProductViewModel ProductViewModel { get { return DataContext as ProductViewModel; } set { DataContext = value; } }
    }
}
