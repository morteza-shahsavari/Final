using Framework.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.DTO.ProductKeyWord
{
    public class ProductKeyWordSearchAddModel:PageModel
    {
        public int ProductID { get; set; }
        public int KeywordID { get; set; }
    }
}
