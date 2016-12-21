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

        public void ClosePopupModal()
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

        public void OpenPopupModal2(string title = "Modal")
        {
            Parameters.save(title.GetHashCode(), title);
            Uri viewUri = new Uri($"/PopupView2?Title={title.GetHashCode().ToString()}", UriKind.RelativeOrAbsolute);
            RegionManager.RequestNavigate(RegionNames.Popup2Region, viewUri);
        }

        public void ClosePopupModal2()
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
