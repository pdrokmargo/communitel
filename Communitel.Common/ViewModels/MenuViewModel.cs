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
        public DelegateCommand OpenConfigurationCommand { get; set; }
        public DelegateCommand OpenSearchUserCommand { get; set; }
        public DelegateCommand OpenCheckInCommand { get; set; }
        public DelegateCommand OpenOrderLookupCommand { get; set; }
        public DelegateCommand OpenSearchCheckInCommand { get; set; }
        [ImportingConstructor]
        public MenuViewModel()
        {
            OpenSearchProductCommand = new DelegateCommand(OpenSearchProductExecute);
            OpenDashBoardCommand = new DelegateCommand(OpenDashBoardExecute);
            OpenConfigurationCommand = new DelegateCommand(OpenConfigurationExecute);
            OpenSearchUserCommand = new DelegateCommand(OpenSearchUserExecute);
            OpenCheckInCommand = new DelegateCommand(OpenCheckInExecute);
            OpenOrderLookupCommand = new DelegateCommand(OpenCheckInExecute);

            OpenSearchCheckInCommand = new DelegateCommand(OpenSearchCheckInExecute);
            Menus = new ObservableCollection<Menu>();

            var list = Variables.User.userprofile.privileges as Newtonsoft.Json.Linq.JArray;
            bool hasUser = list.Where(item => item["id"].ToObject<int>() == (int)Enums.enView.Users).Count() > 0;
            bool hasProduct = list.Where(item => item["id"].ToObject<int>() == (int)Enums.enView.CatalogProducts).Count() > 0;
            bool hasConfiguration = list.Where(item => item["id"].ToObject<int>() == (int)Enums.enView.Configuration).Count() > 0;
            bool hasCheckin = list.Where(item => item["id"].ToObject<int>() == (int)Enums.enView.CheckIn).Count() > 0;
            bool hasOrderLookup = list.Where(item => item["id"].ToObject<int>() == (int)Enums.enView.OrderLookup).Count() > 0;

            //var t = list[0].Value<Newtonsoft.Json.Linq.JObject>("views")["description"];

            Menus.Add(new Menu { Name = "Dashboard", Icon = FontAwesome.WPF.FontAwesomeIcon.Home, Command = OpenDashBoardCommand });
            Menus.Add(new Menu { Name = "Users", Icon = FontAwesome.WPF.FontAwesomeIcon.Users, Command = OpenSearchUserCommand, Visible = hasUser ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed });
            Menus.Add(new Menu { Name = "Catalog Products", Icon = FontAwesome.WPF.FontAwesomeIcon.ShoppingBag, Command = OpenSearchProductCommand, Visible = hasProduct ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed });
            Menus.Add(new Menu { Name = "Configuration", Icon = FontAwesome.WPF.FontAwesomeIcon.Cog, Command = OpenConfigurationCommand, Visible = hasConfiguration ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed });
            Menus.Add(new Menu { Name = "CheckIn", Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle, Command = OpenCheckInCommand, Visible = hasCheckin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed });
            Menus.Add(new Menu { Name = "Order Lookup", Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle, Command = OpenOrderLookupCommand, Visible = hasOrderLookup ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed });
            Menus.Add(new Menu { Name = "CheckIn", Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle, Command = OpenSearchCheckInCommand, Visible = hasCheckin ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed });

            this.FullName = $"{Variables.User.firstname} {Variables.User.lastname}";
            this.Profile = Variables.User.userprofile;
        }

        #region variables
        private ObservableCollection<Models.Menu> _menus;
        private string _fullName;
        private dynamic _profile;
        #endregion

        #region property
        public ObservableCollection<Models.Menu> Menus { get { return _menus; } set { _menus = value; NotifyPropertyChanged("Menus"); } }
        public string FullName { get { return _fullName; } set { _fullName = value; NotifyPropertyChanged("FullName"); } }
        public dynamic Profile { get { return _profile; } set { _profile = value; NotifyPropertyChanged("Profile"); } }
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

        private void OpenConfigurationExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/ConfigurationView");
            }
            catch (Exception ex)
            {

            }
        }

        private void OpenSearchUserExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/SearchUserView");
            }
            catch (Exception ex)
            {

            }
        }

        private void OpenSearchCheckInExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/SearchCheckInView");
            }
            catch (Exception ex)
            {

            }
        }

        private void OpenOrderLookup()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/OrderLookupView");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
