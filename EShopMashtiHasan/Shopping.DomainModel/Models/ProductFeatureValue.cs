using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models
{
  public  class ProductFeatureValue
    {
        public int ProductFeatureValueID { get; set; }
        public int ProductID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureValue { get; set; }
        public Product Product { get; set; }
        public Feature Feature { get; set; }
    }
}
