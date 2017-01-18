using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Functions
{
    public class Functions
    {
        public static bool IsPropertyExist(dynamic settings, string name)
        {
            bool isDefined = false;

            if (settings is Newtonsoft.Json.Linq.JObject)
                isDefined = ((Newtonsoft.Json.Linq.JObject)settings).Property(name) != null;
            else
                isDefined = ((IDictionary<string, object>)settings).ContainsKey(name);
            return isDefined;
        }
    }
}
