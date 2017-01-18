using Communitel.Common.Enums;
using Communitel.Common.Messages;
using Communitel.Common.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.ViewModels
{
    [Export(typeof(PopupModalViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PopupModalViewModel : BaseModel, INavigationAware
    {
        public DelegateCommand ClosePopupModalCommand { get; set; }
        public DelegateCommand ClosePopupModal2Command { get; set; }
        [ImportingConstructor]
        public PopupModalViewModel()
        {
            ClosePopupModalCommand = new DelegateCommand(ClosePopupModalExecute, () => true);
            ClosePopupModal2Command = new DelegateCommand(ClosePopupModal2Execute, () => true);
        }

        private string _title = string.Empty;
        public string Title { get { return _title; } set { _title = value; NotifyPropertyChanged("Tltle"); } }

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }


        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            int hash = int.Parse(navigationContext.Parameters["Title"].ToString());
            Title = Parameters.request(hash).ToString();
        }


        public void ClosePopupModalExecute()
        {
            try
            {
                List<object> contents = new List<object>(RegionManager.Regions[RegionNames.ContentModalRegion].Views);
                foreach (object view in contents)
                    RegionManager.Regions[RegionNames.ContentModalRegion].Remove(view);

                List<object> popups = new List<object>(RegionManager.Regions[RegionNames.PopupRegion].Views);
                foreach (object view in popups)
                    RegionManager.Regions[RegionNames.PopupRegion].Remove(view);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ClosePopupModal2Execute()
        {
            try
            {
                List<object> contents = new List<object>(RegionManager.Regions[RegionNames.ContentModal2Region].Views);
                foreach (object view in contents)
                    RegionManager.Regions[RegionNames.ContentModal2Region].Remove(view);

                List<object> popups = new List<object>(RegionManager.Regions[RegionNames.Popup2Region].Views);
                foreach (object view in popups)
                    RegionManager.Regions[RegionNames.Popup2Region].Remove(view);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
