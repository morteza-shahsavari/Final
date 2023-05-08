using Framework.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.CategoryFeature
{
    public class CategoryFeatureSearchAddModel:PageModel
    {
        public int FeatureID { get; set; }
        public int CategoryID { get; set; }

    }
}
