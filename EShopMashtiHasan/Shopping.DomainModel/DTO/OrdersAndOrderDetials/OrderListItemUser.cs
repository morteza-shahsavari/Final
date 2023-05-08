using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.OrdersAndOrderDetials
{
    public class OrderListItemUser
    {
        public int OrderID { get; set; }
        public string UserName { get; set; }
        public string OrderDescription { get; set; }
        public string OrderDate { get; set; }
        public string Address { get; set; }
        public string RequiredDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string IsFainaly { get; set; }
    }
}
