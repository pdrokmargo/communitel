using Communitel.Common.Behaviour;
using Microsoft.Practices.Prism.MefExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Communitel
{
    public class Bootstrapper : MefBootstrapper
    {

        string shell { get; set; }

        public Bootstrapper()
        {
            shell = "Shell";
        }

        public Bootstrapper(string ShellName)
        {
            shell = ShellName;
        }

        //Inicia la clase Bootstrapper,tenemos que añadirla al AssemblyCatalog
        protected override void ConfigureAggregateCatalog()
        {
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));


            string pluginsPath = AppDomain.CurrentDomain.BaseDirectory;
            foreach (string file in Directory.GetFiles(pluginsPath, "*.Plugins.dll"))
            {
                var asm = Assembly.LoadFrom(file);
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(asm));
            }

            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));

        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            if (shell == "Shell")
                return Container.GetExportedValue<Views.Shell.Shell>();
            /*else if (shell == "Login")
                return Container.GetExportedValue<Login>();*/

            return null;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            if (shell == "Shell")
            {
                Application.Current.MainWindow = (Views.Shell.Shell)this.Shell;
                Application.Current.MainWindow.Show();
            }
            else if (shell == "Login")
            {
                /*Application.Current.MainWindow = (Login)this.Shell;
                Application.Current.MainWindow.Show();*/
            }
        }

        /*static void ActiveRecordStarter_SessionFactoryHolderCreated(Castle.ActiveRecord.Framework.ISessionFactoryHolder holder)
        {
            holder.ThreadScopeInfo = new Castle.ActiveRecord.Framework.Scopes.ThreadScopeInfo();
        }*/

        protected override Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));
            return factory;
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return new Microsoft.Practices.Prism.Modularity.ConfigurationModuleCatalog();
        }
    }
}
