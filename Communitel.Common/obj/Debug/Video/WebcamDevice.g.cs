﻿#pragma checksum "..\..\..\Video\WebcamDevice.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FB24DF3DAE54C06A28E41B52FD2D6445"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AForge.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Communitel.Common.Video {
    
    
    /// <summary>
    /// WebcamDevice
    /// </summary>
    public partial class WebcamDevice : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Video\WebcamDevice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid NoVideoSourceGrid;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Video\WebcamDevice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NoVideoSourceMessage;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Video\WebcamDevice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost VideoSourceWindowsFormsHost;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Video\WebcamDevice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AForge.Controls.VideoSourcePlayer VideoSourcePlayer;
        
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
            System.Uri resourceLocater = new System.Uri("/Communitel.Common;component/video/webcamdevice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Video\WebcamDevice.xaml"
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
            
            #line 10 "..\..\..\Video\WebcamDevice.xaml"
            ((Communitel.Common.Video.WebcamDevice)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WebcamDeviceOnLoaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\Video\WebcamDevice.xaml"
            ((Communitel.Common.Video.WebcamDevice)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.WebcamDeviceOnUnloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NoVideoSourceGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.NoVideoSourceMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.VideoSourceWindowsFormsHost = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 5:
            this.VideoSourcePlayer = ((AForge.Controls.VideoSourcePlayer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
