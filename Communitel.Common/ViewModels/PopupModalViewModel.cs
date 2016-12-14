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
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class PopupModalViewModel : BaseModel, INavigationAware
    {        
        public DelegateCommand ClosePopupModalCommand { get; set; }

        [ImportingConstructor]
        public PopupModalViewModel()
        {
            ClosePopupModalCommand = new DelegateCommand(CerrarPopupModalExecute, () => true);
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

        private void CerrarPopupModalExecute()
        {
            try
            {

                List<object> views2 = new List<object>(RegionManager.Regions[RegionNames.ContentModalRegion].Views);
                foreach (object view in views2)
                {
                    RegionManager.Regions[RegionNames.ContentModalRegion].Remove(view);
                }

                List<object> views = new List<object>(RegionManager.Regions[RegionNames.PopupRegion].Views);
                foreach (object view in views)
                {
                    RegionManager.Regions[RegionNames.PopupRegion].Remove(view);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MessageBoxIconV.Error);
            }
        }

    }
}
