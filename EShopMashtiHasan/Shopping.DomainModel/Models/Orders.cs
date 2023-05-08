using System;
using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
    public  class Orders
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string OrderDescription{ get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public DateTime? RequiredDate { get; set; }
        public decimal TotalAmount{ get; set; }
        public bool IsFainaly { get; set; }
       // public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public Orders()
        {
            this.OrderDetails = new List<OrderDetails>();
           // this.User = new User();
        }
    }
}
