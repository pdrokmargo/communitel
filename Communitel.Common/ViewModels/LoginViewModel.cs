using Communitel.Common.Helpers;
using Communitel.Common.Messages;
using Communitel.Common.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.ViewModels
{
    [Export(typeof(LoginViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LoginViewModel : Models.BaseModel
    {

        public DelegateCommand LoginCommand { get; set; }

        [ImportingConstructor]
        public LoginViewModel()
        {
            User = new System.Dynamic.ExpandoObject();
            LoginCommand = new DelegateCommand(LoginExecute);
        }

        private dynamic _user;
        public dynamic User { get { return _user; } set { _user = value; NotifyPropertyChanged("User"); } }

        private async void LoginExecute()
        {
            try
            {
                if (!Functions.Functions.IsPropertyExist(User, "user") && string.IsNullOrEmpty(User.user))
                {
                    MessageBox.Show("Please enter the user.");
                    return;
                }
                if (string.IsNullOrEmpty(User.password))
                {
                    MessageBox.Show("Please enter the password.");
                    return;
                }
                ServiceRequest s = new ServiceRequest();
                OpenIndicator();
                string parsedContent = "grant_type=password&client_id=" + ConfigurationManager.AppSettings["clientID"] + "&client_secret=" + ConfigurationManager.AppSettings["clientSecret"] + "&username=" + User.user.ToLower() + "&password=" + User.password + "&scope=";
                dynamic obj = await s.requestToken("/oauth/token", parsedContent);
                Variables.Token = (string)obj.access_token;

                Variables.User = await s.GET("/api/userIdentity/" + User.user.ToLower());

                RegionManager.RequestNavigate(RegionNames.NavigationRegion, "/MenuView");
                RegionManager.RequestNavigate(RegionNames.WorkSpaceRegion, "/HomeView");
                CloseIndicator();
            }
            catch (Exception ex)
            {
                CloseIndicator();
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
