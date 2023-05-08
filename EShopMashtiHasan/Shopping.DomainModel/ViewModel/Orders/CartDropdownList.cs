
using System.Collections.Generic;

namespace Shopping.DomainModel.ViewModel.Orders
{
    public class CartDropdownList
    {
        public CartDropdownList()
        {
            CartDropdownListItems = new List<CartDropdownListItem>();
        }
        public string TotalAmount { get; set; }
        public int Count { get; set; }
        public List<CartDropdownListItem> CartDropdownListItems { get; set; }
    }
    public class CartDropdownListItem 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int OrderCount { get; set; }
        public string Image { get; set; }
        public string Price{ get; set; }
    }
}
