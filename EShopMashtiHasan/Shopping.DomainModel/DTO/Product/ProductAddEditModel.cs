

namespace Shopping.DomainModel.DTO.Product
{
   public class ProductAddEditModel
    {
        public int ProductID { get; set; }
       
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SmallDescription { get; set; }
        public string Description { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
    }
}
