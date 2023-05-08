using Framework.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.ProductFeatureValues
{
    public class ProductFeatureSearchAddModel:PageModel
    {
        public int ProductID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureValue { get; set; }
    }
}
