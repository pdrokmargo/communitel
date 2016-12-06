using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communitel.Models;
using System.Windows.Controls;
using Communitel.Views;

namespace Communitel.ViewModel
{
    public class OptionMenuViewModel
    {
        Users userview;
        public OptionMenuViewModel()
        {
            userview = new Users();
        }

        public UserControl activeView
        {
            get;
            set;
        }

        public List<Grid> Menu { get; set; }



    }
}
