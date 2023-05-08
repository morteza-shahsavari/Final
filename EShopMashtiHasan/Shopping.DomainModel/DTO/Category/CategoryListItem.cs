using Shopping.DomainModel.DTO.Product;

using System.Collections.Generic;

namespace Shopping.DomainModel.DTO.Category
{
    public class CategoryListItem
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ParentNames { get; set; }
        public int ChildCount { get; set; }
        public int ProductCount { get; set; }
        public int ParentID { get; set; }

        public ICollection<ProductListItem> Products { get; set; }
        //public CategoryListItem()
        //{
        //    this.Products = new List<ProductListItem>();
        //}
    }
}
