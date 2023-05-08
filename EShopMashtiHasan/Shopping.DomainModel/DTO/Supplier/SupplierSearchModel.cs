using Framework.BaseModel;

namespace Shopping.DomainModel.DTO.Supplier
{
   public class SupplierSearchModel:PageModel
    {
        public string SupplierName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
    }
}
