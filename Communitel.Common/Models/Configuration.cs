using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Models
{
   public class Configuration:NotifyProperty
    {
        private int _id;
        private float _tax_percent;
        private int _expiry_days;
        private float _red_price;
        private float _yellow_price;
        private float _orange_price;
        private float _overorange_price;

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public float tax_percent { get { return _tax_percent; } set { _tax_percent = value; NotifyPropertyChanged("tax_percent"); } }
        public int expiry_days { get { return _expiry_days; } set { _expiry_days = value; NotifyPropertyChanged("expiry_days"); } }
        public float red_price { get { return _red_price; } set { _red_price = value; NotifyPropertyChanged("red_price"); } }
        public float yellow_price { get { return _yellow_price; } set { _yellow_price = value; NotifyPropertyChanged("yellow_price"); } }
        public float orange_price { get { return _orange_price; } set { _orange_price = value; NotifyPropertyChanged("orange_price"); } }
        public float overorange_price { get { return _overorange_price; } set { _overorange_price = value; NotifyPropertyChanged("overorange_price"); } }
    }
}
