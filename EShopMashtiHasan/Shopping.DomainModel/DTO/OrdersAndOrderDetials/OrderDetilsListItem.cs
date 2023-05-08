using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.OrdersAndOrderDetials
{
    public class OrderDetilsListItem
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public long UnitPrice { get; set; }
        public long TotalPrice { get; set; }
    }
}
