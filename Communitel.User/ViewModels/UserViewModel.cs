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
using Newtonsoft.Json;
using Communitel.Common.Functions;
using System.Collections.ObjectModel;

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
        public DelegateCommand OpenSearchCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand<dynamic> OpenEditCommand { get; set; }
        public DelegateCommand OpenMoreFiltersCommand { get; set; }
        [ImportingConstructor]
        public UserViewModel()
        {
            LoadCommand = new DelegateCommand(LoadExecute);
            OpenCreateCommand = new DelegateCommand(OpenCreateExecute);
            GetPrivilegesCommand = new DelegateCommand<object>(GetPrivilegesExecute);
            GetAllCommand = new DelegateCommand(GetAllExecute);
            NextPageCommand = new DelegateCommand<string>(NextPageExecute);
            OpenSearchCommand = new DelegateCommand(OpenSearchExecute);
            SaveCommand = new DelegateCommand(SaveExecute);
            OpenEditCommand = new DelegateCommand<dynamic>(OpenEditExecute);
            OpenMoreFiltersCommand = new DelegateCommand(OpenMoreFiltersExecute);
            User = new System.Dynamic.ExpandoObject();
        }

        #region variables
        private dynamic _users;
        private dynamic _user;
        private dynamic _userProfiles;
        #endregion

        #region properties
        public dynamic Users { get { return _users; } set { _users = value; NotifyPropertyChanged("Users"); } }
        public dynamic User { get { return _user; } set { _user = value; NotifyPropertyChanged("User"); } }
        public dynamic UserProfiles { get { return _userProfiles; } set { _userProfiles = value; NotifyPropertyChanged("UserProfiles"); } }
        public ObservableCollection<Models.UserProfile> MyProperty { get; set; }
        #endregion

        private void LoadExecute()
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        private async void SaveExecute()
        {
            try
            {

                #region validation

                if (!Functions.IsPropertyExist(this.User, "firstname") || string.IsNullOrEmpty(User.firstname.ToString()))
                {
                    MessageBox.Show("Enter the first name", "User", Common.Enums.MessageBoxIconV.Warning);
                    return;
                }
                if (!Functions.IsPropertyExist(this.User, "lastname") || string.IsNullOrEmpty(User.lastname.ToString()))
                {
                    MessageBox.Show("Enter the last name", "User", Common.Enums.MessageBoxIconV.Warning);
                    return;
                }
                if (!Functions.IsPropertyExist(this.User, "username") || string.IsNullOrEmpty(User.username.ToString()))
                {
                    MessageBox.Show("Enter the user name", "User", Common.Enums.MessageBoxIconV.Warning);
                    return;
                }
                if (!Functions.IsPropertyExist(this.User, "email") || string.IsNullOrEmpty(User.email.ToString()))
                {
                    MessageBox.Show("Enter the email", "User", Common.Enums.MessageBoxIconV.Warning);
                    return;
                }

                if (!Functions.IsPropertyExist(this.User, "user_profile_id") || string.IsNullOrEmpty(User.user_profile_id.ToString()))
                {
                    MessageBox.Show("Select the user profile", "User", Common.Enums.MessageBoxIconV.Warning);
                    return;
                }

                #endregion

                ServiceRequest s = new ServiceRequest();

                if (Functions.IsPropertyExist(this.User, "id") && this.User.id > 0)
                {

                    if (Functions.IsPropertyExist(this.User, "password") && !string.IsNullOrEmpty(User.password.ToString()))
                    {
                        if (!Functions.IsPropertyExist(this.User, "confirmpassword") || string.IsNullOrEmpty(User.confirmpassword.ToString()))
                        {
                            MessageBox.Show("Confirm password", "User", Common.Enums.MessageBoxIconV.Warning);
                            return;
                        }

                        if (User.confirmpassword != User.password)
                        {
                            MessageBox.Show("Passwords do not match!", "User", Common.Enums.MessageBoxIconV.Warning);
                            return;
                        }
                    }

                    string json = JsonConvert.SerializeObject(this.User);
                    OpenIndicator();
                    dynamic obj = await s.PUT("/api/users/" + User.id, json);
                    CloseIndicator();
                    MessageBox.Show("The user has been updated!", "User");
                    User = new System.Dynamic.ExpandoObject();
                    this.OpenSearchExecute();
                }
                else
                {
                    if (!Functions.IsPropertyExist(this.User, "password") || string.IsNullOrEmpty(User.password.ToString()))
                    {
                        MessageBox.Show("Enter the password", "User", Common.Enums.MessageBoxIconV.Warning);
                        return;
                    }

                    if (!Functions.IsPropertyExist(this.User, "confirmpassword") || string.IsNullOrEmpty(User.confirmpassword.ToString()))
                    {
                        MessageBox.Show("Confirm password", "User", Common.Enums.MessageBoxIconV.Warning);
                        return;
                    }

                    if (User.confirmpassword != User.password)
                    {
                        MessageBox.Show("Passwords do not match!", "User", Common.Enums.MessageBoxIconV.Warning);
                        return;
                    }

                    OpenIndicator();
                    dynamic result = await s.GET($"/api/users?username={User.username}");
                    var data = (Newtonsoft.Json.Linq.JArray)result.data;
                    if (data.Count == 0)
                    {
                        string json = JsonConvert.SerializeObject(this.User);
                        dynamic obj = await s.POST("/api/users", json);
                        this.User = new System.Dynamic.ExpandoObject();
                        MessageBox.Show("A new user has been created!", "User");
                    }
                    else
                    {
                        MessageBox.Show("User already exists!", "User");
                    }
                    CloseIndicator();
                }
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async Task Get(string search, string sortBy = "id", int reverse = 0)
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                Dictionary<string, object> headers = new Dictionary<string, object>();
                headers.Add("pageSize", 10);
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

        private async void OpenCreateExecute()
        {
            try
            {
                Common.Helpers.ServiceRequest s = new Common.Helpers.ServiceRequest();
                OpenIndicator();
                var result = await s.GET("/api/userprofile");
                CloseIndicator();
                UserProfiles = result.data;
                this.User = new System.Dynamic.ExpandoObject();
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/UserView");
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private async void GetPrivilegesExecute(object user_profile_id)
        {
            try
            {
                if (user_profile_id != null && user_profile_id is Newtonsoft.Json.Linq.JValue)
                {
                    OpenIndicator();
                    Common.Helpers.ServiceRequest s = new Common.Helpers.ServiceRequest();
                    var result = await s.GET($"/api/privileges?user_profile_id={user_profile_id}");
                    this.User.userprofile.privileges = result.data;
                    CloseIndicator();
                }
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

        private void OpenSearchExecute()
        {
            try
            {
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/SearchUserView");
            }
            catch (Exception ex)
            {

            }
        }

        private async void OpenEditExecute(dynamic user)
        {
            try
            {
                ServiceRequest s = new ServiceRequest();
                var profiles = await s.GET("/api/userprofile");
                UserProfiles = profiles.data;
                var result = await s.GET($"/api/users/{user.id}");
                this.User = new System.Dynamic.ExpandoObject();
                this.User = result.data;
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/UserView");
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, Common.Enums.MessageBoxIconV.Error);
            }
        }

        private void OpenMoreFiltersExecute()
        {
            try
            {
                OpenPopupModal("Filters");
                RegionManager.RequestNavigate(RegionNames.ContentModalRegion, "/FilterUserView");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
