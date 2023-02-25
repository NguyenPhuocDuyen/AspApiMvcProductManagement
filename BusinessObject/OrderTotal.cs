using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderTotal
    {
        public Order Order { get; set; }
        public double Total { get; set; }
    }
}
