﻿#pragma checksum "..\..\..\Views\Privileges.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "694DC457E7D0B9876F361FE726643229"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Communitel.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Communitel.Views {
    
    
    /// <summary>
    /// Privileges
    /// </summary>
    public partial class Privileges : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridList;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridForm;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView1;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkCreate;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkRead;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkUpdate;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkDelete;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\Privileges.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Communitel;component/views/privileges.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Privileges.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridList = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.listView = ((System.Windows.Controls.ListView)(target));
            
            #line 11 "..\..\..\Views\Privileges.xaml"
            this.listView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GridForm = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Views\Privileges.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.listView1 = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.chkCreate = ((System.Windows.Controls.CheckBox)(target));
            
            #line 31 "..\..\..\Views\Privileges.xaml"
            this.chkCreate.Click += new System.Windows.RoutedEventHandler(this.chkCreate_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.chkRead = ((System.Windows.Controls.CheckBox)(target));
            
            #line 42 "..\..\..\Views\Privileges.xaml"
            this.chkRead.Click += new System.Windows.RoutedEventHandler(this.chkRead_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.chkUpdate = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\..\Views\Privileges.xaml"
            this.chkUpdate.Click += new System.Windows.RoutedEventHandler(this.chkUpdate_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.chkDelete = ((System.Windows.Controls.CheckBox)(target));
            
            #line 64 "..\..\..\Views\Privileges.xaml"
            this.chkDelete.Click += new System.Windows.RoutedEventHandler(this.chkDelete_Checked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Views\Privileges.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
