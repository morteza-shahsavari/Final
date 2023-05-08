using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Shopping.DomainModel.Models
{
   public class Category
    {
        public int CategoryID { get; set; }
         public string CategoryName { get; set; }
        public string SmallDescription { get; set; }
        public int? ParentID { get; set; }
        public ICollection<Category> Children { get; set; }
        public Category Parent { get; set; }
        public string Lineage { get; set; }
        public int ProductCount { get; set; }
        public int Depth { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
            this.Children = new List<Category>();
            this.CategoryFeatures = new List<CategoryFeature>();
        }
    }
}
