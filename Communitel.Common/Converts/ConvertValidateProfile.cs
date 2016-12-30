using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Communitel.Common.Converts
{
    public class ConvertValidateProfile : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool result = true;          
            //int userProfile = (int)Variables.User.user_profile_id.Value;
            //int profile = value is Newtonsoft.Json.Linq.JValue ? (int)(value as Newtonsoft.Json.Linq.JValue).Value : (int)value;

            //if (userProfile != (int)Enums.enUserProfiles.SuperAdmin && profile == (int)Enums.enUserProfiles.SuperAdmin)
            //    result = false;

            //return result;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool result = true;
            //int userProfile = (int)Variables.User.user_profile_id.Value;
            //int profile = value is Newtonsoft.Json.Linq.JValue ? (int)(value as Newtonsoft.Json.Linq.JValue).Value : (int)value;

            //if (userProfile != (int)Enums.enUserProfiles.SuperAdmin && profile == (int)Enums.enUserProfiles.SuperAdmin)
            //    result = false;

            //return result;
            return true;
        }
    }
}
