using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Models
{
   public class Result<T>
    {
        public string msg { get; set; }
        public T data { get; set; }
    }
}
