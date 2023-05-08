using System;

namespace Shopping.DomainModel.ViewModel.Orders
{
    public class OrdersViewModel
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public DateTime? RequiredDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
