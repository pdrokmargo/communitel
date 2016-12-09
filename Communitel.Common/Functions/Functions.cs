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
            bool isDefined = ((IDictionary<string, object>)settings).ContainsKey(name);
            return isDefined;
        }
    }
}
