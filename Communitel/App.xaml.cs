using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Communitel.Views;

namespace Communitel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Token { get; set; }
        public static dynamic User { get; set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the startup window
            Dashboard wnd = new Dashboard();
            wnd.Show();
        }
    }
}
