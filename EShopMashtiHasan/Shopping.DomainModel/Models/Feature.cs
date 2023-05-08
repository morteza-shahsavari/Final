using System.Collections.Generic;

namespace Shopping.DomainModel.Models
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }
        public ICollection<ProductFeatureValue> ProductFeatureValues { get; set; }

        public Feature()
        {
            this.CategoryFeatures = new List<CategoryFeature>();
            this.ProductFeatureValues = new List<ProductFeatureValue>();

        }
    }
}
