using Communitel.Common.Enums;
using Communitel.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Communitel.CheckIn.Models
{
    class Models
    {
    }

    public class Document
    {
        public string DocumentType { get; set; }
        public string Number { get; set; }
        public ImageSource Image { get; set; }
    }

    public class Customer : NotifyProperty
    {
        private int _id = 0;
        private string _firstname = string.Empty;
        private string _lastname = string.Empty;
        private string _id_number = string.Empty;
        private string _nationality = string.Empty;
        private int _sex;
        private DateTime _date_birth = DateTime.Today;

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public string firstname { get { return _firstname; } set { _firstname = value; NotifyPropertyChanged("firstname"); } }
        public string lastname { get { return _lastname; } set { _lastname = value; NotifyPropertyChanged("lastname"); } }
        public string id_number { get { return _id_number; } set { _id_number = value; NotifyPropertyChanged("id_number"); } }
        public string nationality { get { return _nationality; } set { _nationality = value; NotifyPropertyChanged("nationality"); } }
        public int sex { get { return _sex; } set { _sex = value; NotifyPropertyChanged("sex"); } }
        public DateTime date_birth { get { return _date_birth; } set { _date_birth = value; NotifyPropertyChanged("date_birth"); } }
    }

    public class OrderBag : NotifyProperty
    {

        private int _id;
        private string _order_number;
        private double _balance;
        private float _tax;
        private float _discount = 0;
        private DateTime _date = DateTime.Today;
        private int _customer_id;

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public string order_number { get { return _order_number; } set { _order_number = value; NotifyPropertyChanged("order_number"); } }
        public double balance { get { return _balance; } set { _balance = value; NotifyPropertyChanged("balance"); } }
        public float tax { get { return _tax; } set { _tax = value; NotifyPropertyChanged("tax"); } }
        public float discount { get { return _discount; } set { _discount = value; NotifyPropertyChanged("discount"); } }
        public DateTime date { get { return _date; } set { _date = value; NotifyPropertyChanged("date"); } }
        public int customer_id { get { return _customer_id; } set { _customer_id = value; NotifyPropertyChanged("customer_id"); } }
    }

    public class CheckIn : NotifyProperty
    {
        private Customer _customer;
        private OrderBag _order_bag;
        private ObservableCollection<Attachment> _attachments;
        private ObservableCollection<AutorizationPerson> _autorization_persons;
        private ObservableCollection<OrderBagDetail> _order_detail;
        private double _total = 0;
        private double _subtotal = 0;
        private double _quantity = 0;
        private Payment _payment;

        public CheckIn()
        {
            _customer = new Customer();
            _order_bag = new OrderBag();
            _attachments = new ObservableCollection<Attachment>();
            _autorization_persons = new ObservableCollection<AutorizationPerson>();
            _order_detail = new ObservableCollection<OrderBagDetail>();
            _payment = new Payment();
            attachments.Add(new Attachment { attachtype_id = (int)enDataLookUp.maincustomerphoto, visible = System.Windows.Visibility.Collapsed });
            attachments.Add(new Attachment { attachtype_id = (int)enDataLookUp.boardingpass, visible = System.Windows.Visibility.Collapsed });
        }
        public Customer customer { get { return _customer; } set { _customer = value; NotifyPropertyChanged("customer"); } }
        public OrderBag order_bag { get { return _order_bag; } set { _order_bag = value; NotifyPropertyChanged("order_bag"); } }
        public ObservableCollection<Attachment> attachments { get { return _attachments; } set { _attachments = value; NotifyPropertyChanged("attachments"); } }
        public ObservableCollection<AutorizationPerson> autorization_persons { get { return _autorization_persons; } set { _autorization_persons = value; NotifyPropertyChanged("autorization_persons"); } }
        public ObservableCollection<OrderBagDetail> order_detail { get { return _order_detail; } set { _order_detail = value; NotifyPropertyChanged("order_detail"); } }
        public Payment payment { get { return _payment; } set { _payment = value; NotifyPropertyChanged("payment"); } }

        public double total
        {
            get
            {
                _total = order_detail.Sum(a => a.price);
                return _total;
            }
            set { _total = value; NotifyPropertyChanged("total"); }
        }

        public double quantity
        {
            get
            {
                _quantity = order_detail.Count();
                return _quantity;
            }
            set { _quantity = value; NotifyPropertyChanged("quantity"); }
        }

        public double subtotal
        {
            get
            {
                _subtotal = this.total - order_bag.discount;
                return _subtotal;
            }
            set { _total = value; NotifyPropertyChanged("subtotal"); }
        }

    }

    public class Attachment : NotifyProperty
    {
        private int _id;
        private int _attachtype_id;
        private int _order_id;
        private Bitmap _url_media;
        private Visibility _visible = Visibility.Visible;

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public int attachtype_id { get { return _attachtype_id; } set { _attachtype_id = value; NotifyPropertyChanged("attachtype_id"); } }
        public int order_id { get { return _order_id; } set { _order_id = value; NotifyPropertyChanged("order_id"); } }
        public Bitmap url_media { get { return _url_media; } set { _url_media = value; NotifyPropertyChanged("url_media"); } }
        public Visibility visible { get { return _visible; } set { _visible = value; NotifyPropertyChanged("visible"); } }
    }

    public class AutorizationPerson : NotifyProperty
    {
        private int _id;
        private int _order_bag_id;
        private int _customer_id;
        private Customer _customer;

        public AutorizationPerson()
        {
            _customer = new Customer();
        }

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public int order_bag_id { get { return _order_bag_id; } set { _order_bag_id = value; NotifyPropertyChanged("order_bag_id"); } }
        public int customer_id { get { return _customer_id; } set { _customer_id = value; NotifyPropertyChanged("customer_id"); } }
        public Customer customer { get { return _customer; } set { _customer = value; NotifyPropertyChanged("customer"); } }

    }

    public class OrderBagDetail : NotifyProperty
    {
        private int _id;
        private int _order_bag_id;
        private string _location_label;
        private string _comments;
        private float _weight;
        private int _length_type;
        private double _price;
        private DateTime _check_in_date;
        private DateTime _check_out_datepublic;

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public int order_bag_id { get { return _order_bag_id; } set { _order_bag_id = value; NotifyPropertyChanged("order_bag_id"); } }
        public string location_label { get { return _location_label; } set { _location_label = value; NotifyPropertyChanged("location_label"); } }
        public string comments { get { return _comments; } set { _comments = value; NotifyPropertyChanged("comments"); } }
        public float weight { get { return _weight; } set { _weight = value; NotifyPropertyChanged("weight"); } }
        public int length_type { get { return _length_type; } set { _length_type = value; NotifyPropertyChanged("length_type"); } }
        public double price { get { return _price; } set { _price = value; NotifyPropertyChanged("price"); } }
        public DateTime check_in_date { get { return _check_in_date; } set { _check_in_date = value; NotifyPropertyChanged("check_in_date"); } }
        public DateTime check_out_datepublic { get { return _check_out_datepublic; } set { _check_out_datepublic = value; NotifyPropertyChanged("check_out_datepublic"); } }
    }

    public class Payment : NotifyProperty
    {
        private int _id;
        private int _order_id;
        private int _payment_method_id;
        private double _value;
        private DateTime _date;

        public int id { get { return _id; } set { _id = value; NotifyPropertyChanged("id"); } }
        public int order_id { get { return _order_id; } set { _order_id = value; NotifyPropertyChanged("order_id"); } }
        public int payment_method_id { get { return _payment_method_id; } set { _payment_method_id = value; NotifyPropertyChanged("payment_method_id"); } }
        public double value { get { return _value; } set { _value = value; NotifyPropertyChanged("value"); } }
        public DateTime date { get { return _date; } set { _date = value; NotifyPropertyChanged("date"); } }
    }

}
