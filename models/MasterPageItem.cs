using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.models
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}
