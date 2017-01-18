using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Communitel.Common.Models;
using Communitel.Common.Helpers;
using Newtonsoft.Json;
using Microsoft.Practices.Prism.Commands;

namespace Communitel.Common.ViewModels
{
    [Export(typeof(ConfigurationViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ConfigurationViewModel : Models.BaseModel
    {

        public DelegateCommand LoadCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        public ConfigurationViewModel()
        {
            LoadCommand = new DelegateCommand(LoadExecute);
            SaveCommand = new DelegateCommand(SaveExecute);
            CloseCommand = new DelegateCommand(CloseExecute);
            Configuration = new System.Dynamic.ExpandoObject();
        }

        private dynamic _configuration;
        public dynamic Configuration { get { return _configuration; } set { _configuration = value; NotifyPropertyChanged("Configuration"); } }

        private async void LoadExecute()
        {
            try
            {
                OpenIndicator();
                ServiceRequest s = new ServiceRequest();
                Configuration = await s.GET("/api/config");
                CloseIndicator();               
            }
            catch (Exception ex)
            {
                CloseIndicator();
            }
        }

        private async void SaveExecute()
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                OpenIndicator();
                string json = JsonConvert.SerializeObject(Configuration);
                await s.PUT("/api/config/change", json);
                CloseIndicator();
                Messages.MessageBox.Show("Configuration updated successfully!", "Content Updated");
            }
            catch (Exception ex)
            {
                CloseIndicator();
                Messages.MessageBox.Show(ex.Message, Enums.MessageBoxIconV.Error);
            }
        }

        private void CloseExecute()
        {
            try
            {
                List<object> contents = new List<object>(RegionManager.Regions[RegionNames.WorkSpaceRegion].Views);
                if (contents != null && contents.Count > 0)
                    foreach (object view in contents)
                        RegionManager.Regions[RegionNames.WorkSpaceRegion].Remove(view);
            }
            catch (Exception ex)
            {
                Messages.MessageBox.Show(ex.Message, Enums.MessageBoxIconV.Error);
            }
        }

    }
}
