using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.RelatedProduct
{
    public class RelatedProductAdd
    {
        public int RelatedProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductRelatedName { get; set; }
        public int ProductID { get; set; }
    }
}
