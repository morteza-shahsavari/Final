namespace Shopping.DomainModel.Models
{
    public  class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public long UnitPrice { get; set; }
        public long TotalPrice { get; set; }
        public Orders Orders { get; set; }
        public Product Product { get; set; }
    }
}
