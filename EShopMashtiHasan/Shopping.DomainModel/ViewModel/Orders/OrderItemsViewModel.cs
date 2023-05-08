namespace Shopping.DomainModel.ViewModel.Orders
{
    public class OrderItemsViewModel
    {
        public int OrderDetailId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public long UnitPrice { get; set; }
        public long TotalPrice { get; set; }
    }
}
