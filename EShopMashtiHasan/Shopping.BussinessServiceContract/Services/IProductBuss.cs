using System.Collections.Generic;

using Framework.BaseModel;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.ProductFeatureValues;
using Shopping.DomainModel.DTO.ProductKeyWord;
using Shopping.DomainModel.DTO.RelatedProduct;
using Shopping.DomainModel.Models;

namespace Shopping.BusinessServiceContract.Services
{
    public interface IProductBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(Product current);
        OperationResult AddNew(Product current);
        Product Get(int id);
        List<Product> GetAll();
        ProductComplexResult Search(ProductSearchModel sm, out int RecordCount);
        OperationResult AddNewProductFeatureValue(ProductFeatureValue current);
        List<ProductFeatureValue> GetProductFeatureValueByProductId(int productId);




        OperationResult AddGetKeyWord(ProductKeyWord model);
        OperationResult DeleteGetKeyWord(int id);
        List<ProductKeyWordListItem> searchGetKeyWord(ProductKeyWordSearchAddModel sm, out int RecordCount);



        OperationResult AddRelated(RelatedProduct model);
        OperationResult DeleteRelated(int id);
        List<RelatedProductListItem> searchRelated(RelatedProductsearchAddModel sm, out int RecordCount);


        OperationResult AddAllNewKeyword(int[] Keyword, int id);
        bool HasDublicateKeyword(int KeywordID, int ProductID);

        List<Product> SearchRelatedToName(string search);
        OperationResult AddAllNewRelatedTo(int[] RelatedTo, int id);



        List<ProductFeatureListItem> searchfeature(ProductFeatureSearchAddModel sm, out int RecordCount);


        OperationResult AddFeature(ProductFeatureSearchAddModel model);
        OperationResult DeleteFeature(int id);




        OperationResult UpdateFeature(int id,string values);


        OperationResult UpdateَAllProductFeature(List<productFeatureUpdate> obj);
    }
}
