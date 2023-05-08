using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.CategoryFeature
{
    public class CategoryFeatureListItem
    {
        public int CategoryFeatureID { get; set; }
        public string FeatureName { get; set; }
        public string CategoryName { get; set; }
    }
}
