
using Framework.BaseModel;

namespace Shopping.DomainModel.DTO.Product
{
   public class ProductSearchModel : PageModel
    {
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
    }
}
