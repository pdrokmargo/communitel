using Communitel.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communitel.User.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Communitel.Common.Messages;
using Communitel.Common.Helpers;

namespace Communitel.User.ViewModels
{
    [Export(typeof(UserViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserViewModel : BaseModel
    {

        public DelegateCommand LoadCommand { get; set; }
        public DelegateCommand OpenCreateCommand { get; set; }
        public DelegateCommand<object> GetPrivilegesCommand { get; set; }
        public DelegateCommand GetAllCommand { get; set; }
        public DelegateCommand<string> NextPageCommand { get; set; }
        [ImportingConstructor]
        public UserViewModel()
        {
            LoadCommand = new DelegateCommand(LoadExecute);
            OpenCreateCommand = new DelegateCommand(OpenCreateExecute);
            GetPrivilegesCommand = new DelegateCommand<object>(GetPrivilegesExecute);
            GetAllCommand = new DelegateCommand(GetAllExecute);
            NextPageCommand = new DelegateCommand<string>(NextPageExecute);
            User = new System.Dynamic.ExpandoObject();
        }

        #region variables
        private dynamic _users;
        private dynamic _user;
        private List<UserProfile> _userProfiles;
       
        #endregion

        #region properties
        public dynamic Users { get { return _users; } set { _users = value; NotifyPropertyChanged("Users"); } }
        public dynamic User { get { return _user; } set { _user = value; NotifyPropertyChanged("User"); } }
        public List<Models.UserProfile> UserProfiles { get { return _userProfiles; } set { _userProfiles = value; NotifyPropertyChanged("UserProfiles"); } }        
        #endregion

        private async void LoadExecute()
        {
            try
            {
                OpenIndicator();
                this.User = new System.Dynamic.ExpandoObject();
                Common.Helpers.ServiceRequest s = new Common.Helpers.ServiceRequest();
                var result = await s.GET<Common.Models.Result<List<Models.UserProfile>>>("/api/userprofile");
                UserProfiles = result.data;
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
            }
        }

        private async Task Get(string search, string sortBy = "id", int reverse = 0)
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                Dictionary<string, object> headers = new Dictionary<string, object>();
                headers.Add("pageSize", 4);
                headers.Add("sortBy", sortBy);
                headers.Add("reverse", reverse);
                dynamic result;
                //if (_filters)
                //{
                //    string categories = string.Empty;
                //    foreach (var item in CategoriesFilters)
                //    {
                //        if (item.add)
                //            categories += $"{item.id},";
                //    }
                //    result = await s.GET($"/api/users?page={Page}&categories={categories}&status={StatusFilter}", headers);
                //}
                //else
                //{
                //    result = await s.GET($"/api/products?page={Page}&search={Search}", headers);
                //}

                result = await s.GET($"/api/users?page={Page}&search={Search}", headers);
                this.Users = result.data;
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void GetAllExecute()
        {
            //_filters = false;
            await GetAll();
        }

        public async Task GetAll()
        {
            try
            {
                OpenIndicator();
                await Get(this.Search, this.SortBy, this.Reverse);
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenCreateExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/UserView");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void GetPrivilegesExecute(object user_profile_id)
        {
            try
            {
                OpenIndicator();
                Common.Helpers.ServiceRequest s = new Common.Helpers.ServiceRequest();
                var result = await s.GET($"/api/privileges?user_profile_id={user_profile_id}");
                this.User.privileges = result.data;
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
            }
        }

        private async void NextPageExecute(string option)
        {
            try
            {
                OpenIndicator();

                if (option == "next")
                {
                    if (Page < int.Parse(this.Users.last_page.ToString()))
                        Page++;
                }
                else
                {
                    if (Page > 1)
                        Page--;
                }

                await Get(this.Search, this.SortBy, this.Reverse);
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

    }
}
