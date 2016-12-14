using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Product.Models
{
   public class Categories:Common.Models.NotifyProperty
    {
        private bool _add;
        public bool add { get { return _add; } set { _add = value; NotifyPropertyChanged("add"); } }
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int lookup_id { get; set; }
    }
}
