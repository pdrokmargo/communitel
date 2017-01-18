using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Communitel.Common.Converts
{
    public class ConvertToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if (value is Newtonsoft.Json.Linq.JValue)
            {
                result = (bool)(value as Newtonsoft.Json.Linq.JValue).Value;
            }
            else {
                result = bool.Parse(value.ToString());
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if (value is Newtonsoft.Json.Linq.JValue)
            {
                result = (bool)(value as Newtonsoft.Json.Linq.JValue).Value;
            }
            else
            {
                result = bool.Parse(value.ToString());
            }
            return result;
        }
    }
}
