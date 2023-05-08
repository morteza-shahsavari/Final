using Framework.BaseModel;


namespace Shopping.DomainModel.DTO.RelatedProduct
{
    public class RelatedProductsearchAddModel: PageModel
    {
        public int ProductID { get; set; }
        public int RelatedToID { get; set; }
    }
}
