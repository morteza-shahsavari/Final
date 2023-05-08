using DataAccessServiceContract.Services;

using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.ProductFeatureValues;
using Shopping.DomainModel.DTO.ProductKeyWord;
using Shopping.DomainModel.DTO.RelatedProduct;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace shopping.Buessiness.Impelements
{
    public class ProductBuss : IProductBuss
    {

        #region Fields

        private readonly IProductRepository repo;


        #endregion

        #region Ctor

        public ProductBuss(IProductRepository repo)
        {
            this.repo = repo;
        }
        
        #endregion

        #region Events 

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public OperationResult Update(Product current)
        {
            return repo.Update(current);
        }

        public OperationResult AddNew(Product current)
        {
           var op  =repo.AddNew(current);
            if (op.Success)
            {
                var catFea=repo.categoryFeatureOnBaseCategoryIDForAddFeatureProduct(current.CategoryID);
                if(catFea!=null)
                foreach (var item in catFea)
                {
                    var q = new ProductFeatureSearchAddModel
                    {
                        ProductID = op.RecordID,
                        FeatureID = item.FeatureID,
                        FeatureValue = ""
                    };
                    repo.AddFeature(q);
                }
                return op.Succeed("Add product And All Feature ");
            }
            return op;
        }

        public Product Get(int id)
        {
            return repo.Get(id);
        }

        public List<Product> GetAll()
        {
            return repo.GetAll();
        }

        public ProductComplexResult Search(ProductSearchModel sm, out int RecordCount)
        {
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult AddNewProductFeatureValue(ProductFeatureValue current)
        {
            return repo.AddNewProductFeatureValue(current);
        }

        public List<ProductFeatureValue> GetProductFeatureValueByProductId(int productId) 
        {
            return repo.GetProductFeatureValueByProductId(productId);
        }

        public OperationResult AddGetKeyWord(ProductKeyWord model)
        {
            return repo.AddGetKeyWord(model);
        }

        public OperationResult DeleteGetKeyWord(int id)
        {
            return repo.DeleteGetKeyWord(id);
        }

        public List<ProductKeyWordListItem> searchGetKeyWord(ProductKeyWordSearchAddModel sm, out int RecordCount)
        {
            return repo.searchGetKeyWord(sm, out RecordCount);
        }




        public OperationResult AddRelated(RelatedProduct model)
        {
           return repo.AddRelated(model);
        }

        public OperationResult DeleteRelated(int id)
        {
            return repo.DeleteRelated(id);
        }

        public List<RelatedProductListItem> searchRelated(RelatedProductsearchAddModel sm, out int RecordCount)
        {
            return repo.searchRelated(sm, out RecordCount);
        }







        public OperationResult AddAllNewKeyword(int[] Keyword, int id)
        {
            foreach (var item in Keyword)
            {
                if (repo.HasDublicateKeyword(item, id))
                {
                    continue;
                }
                else
                {
                    var q = new ProductKeyWord
                    {
                        ProductID = id,
                        KeywordID = item
                    };
                    repo.AddGetKeyWord(q);
                }

            }
            OperationResult op = new OperationResult("Add feature Category").Succeed("Add feature Category");
            return op;
        }

        public bool HasDublicateKeyword(int KeywordID, int ProductID)
        {
            return repo.HasDublicateKeyword(KeywordID, ProductID);
        }

        public List<Product> SearchRelatedToName(string search)
        {
            return repo.SearchRelatedToName(search);
        }

        public OperationResult AddAllNewRelatedTo(int[] RelatedTo, int id)
        {
            foreach (var item in RelatedTo)
            {
                if (repo.HasDublicateRelatedTo(item, id))
                {
                    continue;
                }
                else
                {
                    var q = new RelatedProduct
                    {
                        ProductID = id,
                        RelatedToID = item
                    };
                    repo.AddRelated(q);
                }

            }
            OperationResult op = new OperationResult("Add Related Product").Succeed("Add Related Product");
            return op;
        }

        public List<ProductFeatureListItem> searchfeature(ProductFeatureSearchAddModel sm, out int RecordCount)
        {
            return repo.searchfeature(sm, out RecordCount);
        }

        public OperationResult AddFeature(ProductFeatureSearchAddModel model)
        {
            if (repo.ExitsFeature(model.FeatureID, model.ProductID))
            {
                return new OperationResult("Add Feature")
                    .Failed("Feature Already Exist");
            }
            return repo.AddFeature(model);
        }

        public OperationResult DeleteFeature(int id)
        {
            return repo.DeleteFeature(id);
        }

        public OperationResult UpdateFeature(int id, string values)
        {
           return repo.UpdateFeature(id, values);
        }

        public OperationResult UpdateَAllProductFeature(List<productFeatureUpdate> obj)
        {
            
                foreach (var item in obj)
                {
                    repo.UpdateFeature(item.ProductFeatureValueID, item.FeatureValue);
                }
                OperationResult op = new OperationResult("Updateَ All Product Feature").Succeed("Updateَ All Product Feature");
                return op;
         
              

        }












        #endregion

    }
}