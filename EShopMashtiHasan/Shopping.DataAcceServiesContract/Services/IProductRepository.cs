using Framework.Shopping.Base;
using Shopping.DomainModel.Models;



using System.Collections.Generic;
using Framework.BaseModel;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.ProductFeature;
using Shopping.DomainModel.DTO.ProductKeyWord;
using Shopping.DomainModel.DTO.RelatedProduct;
using Shopping.DomainModel.DTO.ProductFeatureValues;

namespace DataAccessServiceContract.Services
{
    public interface IProductRepository : IBaseRepositorySearchable<Product, int, ProductSearchModel, Shopping.DomainModel.DTO.Product.ProductComplexResult>
    {
        OperationResult AddNewProductFeatureValue(ProductFeatureValue current);
        List<ProductFeatureValue> GetProductFeatureValueByProductId(int productId);
       // List<ProductKeyWordListItem> GetKeyWord(int id);

        OperationResult AddGetKeyWord(ProductKeyWord model);
        OperationResult DeleteGetKeyWord(int id);
        List<ProductKeyWordListItem> searchGetKeyWord(ProductKeyWordSearchAddModel sm, out int RecordCount);


        bool HasDublicateKeyword(int KeywordID, int ProductID);
        bool HasDublicateRelatedTo(int RelatedToID, int ProductID);

        List<Product> SearchRelatedToName(string search);



        OperationResult AddRelated(RelatedProduct model);

       
        OperationResult DeleteRelated(int id);
        List<RelatedProductListItem> searchRelated(RelatedProductsearchAddModel sm, out int RecordCount);

        List<ProductFeatureListItem> searchfeature(ProductFeatureSearchAddModel sm, out int RecordCount);




        OperationResult AddFeature(ProductFeatureSearchAddModel model);

        bool ExitsFeature(int FeatureID, int ProductId);
        OperationResult DeleteFeature(int id);
        List<CategoryFeature> categoryFeatureOnBaseCategoryIDForAddFeatureProduct(int CategoryID);


        OperationResult UpdateFeature(int id, string values);

    }
}
