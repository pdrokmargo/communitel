using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Communitel.Common.Models;

namespace Communitel.Common.ViewModels
{
    [Export(typeof(ConfigurationViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ConfigurationViewModel : Models.BaseModel
    {
    }
}
