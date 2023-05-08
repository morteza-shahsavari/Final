using System;
using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SmallDescription  { get; set; }
        public string Description { get; set; }
        public int SupplierID { get; set; }
        public bool ShowInAmazingOffer { get; set; }
        public bool ShowInInstantOffer { get; set; }
        public DateTime? ExpireDateSpecialOffer { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<RelatedProduct> Products { get; set; }
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
        public ICollection<ProductFeatureValue> ProductFeatureValues { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<ProductKeyWord> ProductKeyWords { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public bool IsNew { get; set; }

        public Product()
        {
            this.Products = new List<RelatedProduct>();
            this.RelatedProducts = new List<RelatedProduct>();
            this.ProductFeatureValues = new List<ProductFeatureValue>();
            this.OrderDetails = new List<OrderDetails>();
            this.ProductKeyWords = new List<ProductKeyWord>();
        }
    }
}
