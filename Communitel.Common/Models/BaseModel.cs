using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        public string NameTabItem
        {
            get;
            protected set;
        }

        protected IRegion FindRegion(string regionName)
        {
            return RegionManager.Regions.FirstOrDefault(r => r.Name == regionName);
        }

        protected bool ActivateView<T>(string regionName)
             where T : class
        {
            var region = FindRegion(regionName);
            if (region == null)
                return false;

            var view = FindView<T>(regionName);
            if (view != null)
            {
                region.Activate(view);
                return true;
            }


            return false;
        }

        protected T FindView<T>(string regionName)
             where T : class
        {
            var region = FindRegion(regionName);
            if (region == null)
                return null;

            return region.Views.FirstOrDefault(v => v is T) as T;
        }

        //Notify Navigation 
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public void OpenIndicator()
        {
            RegionManager.RequestNavigate("IndicatorRegion", "/IndicatorView");
        }

        public void CloseIndicator()
        {
            try
            {
                List<object> contents = new List<object>(RegionManager.Regions[RegionNames.IndicatorRegion].Views);
                if (contents != null && contents.Count > 0)
                    foreach (object view in contents)
                        RegionManager.Regions[RegionNames.IndicatorRegion].Remove(view);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OpenPopupModal(string title = "Modal")
        {
            Parameters.save(title.GetHashCode(), title);
            Uri viewUri = new Uri($"/PopupView?Title={title.GetHashCode().ToString()}", UriKind.RelativeOrAbsolute);
            RegionManager.RequestNavigate(RegionNames.PopupRegion, viewUri);
        }

    }
}
