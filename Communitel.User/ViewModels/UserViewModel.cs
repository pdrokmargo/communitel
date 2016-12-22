using Communitel.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.User.ViewModels
{
    [Export(typeof(UserViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserViewModel:BaseModel
    {
        [ImportingConstructor]
        public UserViewModel()
        {

        }
    }
}
