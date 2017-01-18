using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Extensions
{
   public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list.Cast<T>());
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            return new ObservableCollection<T>(list.Cast<T>());
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this T[] list)
        {
            return new ObservableCollection<T>(list.Cast<T>());
        }
    }
}
