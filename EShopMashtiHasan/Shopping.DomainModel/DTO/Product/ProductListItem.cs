using System;

namespace Shopping.DomainModel.DTO.Product
{
    public class ProductListItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public int UnitPrice { get; set; }
        public string Picture1 { get; set; }
        public int CategoryID { get; set; }
        public bool ShowInAmazingOffer { get; set; }
        public bool ShowInInstantOffer { get; set; }
        public DateTime? ExpireDateSpecialOffer{ get; set; }
        public bool IsNew { get; set; }
        public string SmallDescription { get; set; }
    }
}
