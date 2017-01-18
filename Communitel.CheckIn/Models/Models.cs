using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public class Person
    {
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string SurName2 { get; set; }
    }

    public class Bag
    {
        public string Length { get; set; }
        public string Weight { get; set; }
        public decimal Price { get; set; }
    }

}
