using Communitel.Common.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.ViewModels
{
    [Export(typeof(MenuViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MenuViewModel : BaseModel
    {

        public DelegateCommand OpenSearchProductCommand { get; set; }
        public DelegateCommand OpenDashBoardCommand { get; set; }
        [ImportingConstructor]
        public MenuViewModel()
        {
            OpenSearchProductCommand = new DelegateCommand(OpenSearchProductExecute);
            OpenDashBoardCommand = new DelegateCommand(OpenDashBoardExecute);
            Menus = new ObservableCollection<Menu>();
            Menus.Add(new Menu { Name = "Dashboard", Icon = FontAwesome.WPF.FontAwesomeIcon.Home, Command = OpenDashBoardCommand });
            Menus.Add(new Menu { Name = "Users", Icon = FontAwesome.WPF.FontAwesomeIcon.Users });
            Menus.Add(new Menu { Name = "Catalog Products", Icon = FontAwesome.WPF.FontAwesomeIcon.ShoppingBag, Command = OpenSearchProductCommand });
        }

        #region variables
        private ObservableCollection<Models.Menu> _menus;
        public dynamic Product { get; set; }
        #endregion

        #region property
        public ObservableCollection<Models.Menu> Menus { get { return _menus; } set { _menus = value; NotifyPropertyChanged("Menus"); } }
        #endregion

        private void OpenSearchProductExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/SearchProductView");
            }
            catch (Exception ex)
            {

            }
        }

        private void OpenDashBoardExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/HomeView");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
