﻿using Communitel.CheckIn.ViewModels;
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

namespace Communitel.CheckIn.Views
{
    /// <summary>
    /// Lógica de interacción para CameraCaptureDocumentView.xaml
    /// </summary>
    [Export("CameraCaptureDocumentView")]
    public partial class CameraCaptureDocumentView : UserControl
    {
        public CameraCaptureDocumentView()
        {
            InitializeComponent();
        }

        [Import]
        public CheckInViewModel CheckInViewModel { get { return DataContext as CheckInViewModel; } set { DataContext = value; } }
    }
}
