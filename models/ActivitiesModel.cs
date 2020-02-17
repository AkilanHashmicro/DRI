using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.models
{
  public  class ActivitiesModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string NextDate { get; set; }

        public ActivitiesModel(int id, string productName, string customerName, string nextDate)
        {
            Id = id;
            ProductName = productName;
            CustomerName = customerName;
            NextDate = nextDate;
        }
    }
}
