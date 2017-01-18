using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.CompositeCommands
{
    public static class CompositeCommands
    {
        public static CompositeCommand OpenCreateProduct = new CompositeCommand();
        public static CompositeCommand OpenSearchProduct = new CompositeCommand();
    }
}
