using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Product.Models
{
    public class Categories : Common.Models.NotifyProperty
    {
        private bool _add;
        private string _description = string.Empty;
        private string _code = string.Empty;

        public bool add { get { return _add; } set { _add = value; NotifyPropertyChanged("add"); } }
        public int id { get; set; }
        public string code { get { return _code; } set { _code = value; NotifyPropertyChanged("code"); } }
        public string description { get { return _description; } set { _description = value; NotifyPropertyChanged("description"); } }
        public int lookup_id { get; set; }
    }
}
