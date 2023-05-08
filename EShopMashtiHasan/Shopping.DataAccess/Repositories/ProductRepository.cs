using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessServiceContract.Services;

using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.ProductFeatureValues;
using Shopping.DomainModel.DTO.ProductKeyWord;
using Shopping.DomainModel.DTO.RelatedProduct;
using Shopping.DomainModel.Models;

namespace Shopping.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Fields
        private readonly DomainModel.Models.EshopMashtiHasanContext db;
        #endregion

        #region Ctor
        public ProductRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }
        #endregion

        #region product
        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Product", id);
            var p = db.Products.FirstOrDefault(x => x.ProductID == id);
            if (p == null)
                return op.Failed("ProductID does not Exist", id);
            try
            {
                db.Products.Remove(p);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }
        }

        public OperationResult Update(Product current)
        {
            OperationResult op = new OperationResult("Update Product", current.ProductID);
            try
            {
                db.Products.Attach(current);
                db.Entry(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Successfully", current.ProductID);
            }
            catch (Exception)
            {
                return op.Failed("Update Failed ", current.ProductID);
            }
        }

        public OperationResult AddNew(Product current)
        {
            OperationResult op = new OperationResult("Add Product");
            try
            {
                db.Products.Add(current);
                db.SaveChanges();
                return op.Succeed("Add Successfully", current.ProductID);
            }
            catch (Exception )
            {
                return op.Failed("Add New Product Failed ");
            }
        }

        public Product Get(int id)
        {
            return db.Products.Include(x=>x.Category).
                ThenInclude(x=>x.CategoryFeatures).ThenInclude(x => x.Feature).ThenInclude(x=>x.ProductFeatureValues).FirstOrDefault(x => x.ProductID == id);
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        
        }

        public ProductComplexResult Search(ProductSearchModel sm, out int RecordCount)
        {
            List<string> ErrorList = new List<string>();
            List<ProductListItem> CategoryListItems;

            try
            {

                var q = from item in db.Products select item;

                if (!string.IsNullOrEmpty(sm.ProductName))
                {
                    q = q.Where(x => x.ProductName.Contains(sm.ProductName));
                }

                if (sm.CategoryID != null && sm.CategoryID > 0)
                {

                    q = q.Where(x => x.CategoryID == sm.CategoryID);
                }

                RecordCount = q.Count();
                var r = q.OrderByDescending(x => x.ProductID).Select(x=> new ProductListItem{
                    ProductID = x.ProductID
                            ,
                    CategoryName = x.Category.CategoryName
                            ,
                    Picture1 = x.Picture1
                            ,
                    ProductName = x.ProductName
                            ,
                    SupplierName = x.Supplier.SupplierName
                            ,
                    UnitPrice = x.UnitPrice


                }).Skip(sm.PageIndex * sm.PageSize)
                    .Take(sm.PageSize).ToList();
                ProductComplexResult results = new ProductComplexResult
                {
                    Errors = null,
                    MainResults = r
                };
                return results;

            }
            catch (Exception ex)
            {
                ErrorList.Add("خطا در بازیابی" + ex.Message);
                ProductComplexResult results = new ProductComplexResult
                {
                    Errors = ErrorList,
                    MainResults = null
                };
                RecordCount = 0;
                return results;
            }
        }



        #endregion


        #region KeyWord
       
        public OperationResult DeleteGetKeyWord(int id)
        {
            OperationResult op = new OperationResult("Delete KeyWord", id);
            var cat = db.ProductKeyWords.Single(x => x.ProductKeyWordID == id);
            if (cat == null)
                return op.Failed("ProductID does not Exist", id);
            try
            {
                db.ProductKeyWords.Remove(cat);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }

        }

        public List<ProductKeyWordListItem> searchGetKeyWord(ProductKeyWordSearchAddModel sm, out int RecordCount)
        {
            var q = from p in db.Products
                    join pk in db.ProductKeyWords on p.ProductID equals pk.ProductID
                    join k in db.KeyWords on pk.KeywordID equals k.KeyWordID
                    select new ProductKeyWordGET
                    {
                        ProductKeyWordID = pk.ProductKeyWordID,
                        KeyWordText = k.KeyWordText,
                        ProductName = p.ProductName,
                        ProductID = pk.ProductID,
                    };

            if (sm.ProductID != null)
            {
                q = q.Where(x => x.ProductID == sm.ProductID);
            }

            RecordCount = q.Count();
            return q.OrderByDescending(x=>x.ProductID).Select(x => new ProductKeyWordListItem
            {
                ProductName = x.ProductName,
                KeyWordText = x.KeyWordText,
                ProductKeyWordID = x.ProductKeyWordID

            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult AddGetKeyWord(ProductKeyWord model)
        {
            OperationResult op = new OperationResult("Add KeyWord");
            try
            {
                var pk = new ProductKeyWord
                {
                    KeywordID = model.KeywordID,
                    
                    ProductID = model.ProductID,
                   
                };

                var q = db.ProductKeyWords.Add(pk);
                db.SaveChanges();

                return op.Succeed("Add Successfully", model.ProductKeyWordID);
            }
            catch (Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message);
            }
        }


        public bool HasDublicateKeyword(int KeywordID, int ProductID)
        {
            return db.ProductKeyWords.Any(x => x.KeywordID == KeywordID && x.ProductID == ProductID);
        }
        #endregion


        #region Related
        public OperationResult AddRelated(RelatedProduct model)
        {
            OperationResult op = new OperationResult("Add Related");
            try
            {
                var q = db.RelatedProducts.Add(new RelatedProduct
                {
                    RelatedToID = model.RelatedToID,
                    ProductID = model.ProductID
                });
                db.SaveChanges();
                return op.Succeed("Add Successfully", model.RelatedProductID);
            }
            catch (Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message);
            }
        }

        public OperationResult DeleteRelated(int id)
        {
            OperationResult op = new OperationResult("Delete Related", id);
            var cat = db.RelatedProducts.Single(x => x.RelatedProductID == id);
            if (cat == null)
                return op.Failed("ProductID does not Exist", id);
            try
            {
                db.RelatedProducts.Remove(cat);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }
        }

        public bool HasDublicateRelatedTo(int RelatedToID, int ProductID)
        {
            return db.RelatedProducts.Any(x => x.RelatedToID == RelatedToID && x.ProductID == ProductID);
        }

        public List<Product> SearchRelatedToName(string search)
        {
            var q = from item in db.Products select item;
            if (!string.IsNullOrEmpty(search))
            {

                q = q.Where(x => x.ProductName.Contains(search));
                return q.ToList();
            }

            else return q.ToList();
        }


        public List<RelatedProductListItem> searchRelated(RelatedProductsearchAddModel sm, out int RecordCount)
        {
            var q = from p in db.Products
                    join pk in db.RelatedProducts on p.ProductID equals pk.ProductID
                    join k in db.Products on pk.RelatedToID equals k.ProductID
                    select new RelatedProductAdd
                    {
                        RelatedProductID = pk.RelatedProductID,
                        ProductRelatedName = k.ProductName,
                        ProductName = p.ProductName,
                        ProductID = pk.ProductID,
                    };

            if (sm.ProductID != null)
            {
                q = q.Where(x => x.ProductID == sm.ProductID);
            }

            RecordCount = q.Count();
            return q.Select(x => new RelatedProductListItem
            {
                ProductName = x.ProductName,
                ProductRelatedName = x.ProductRelatedName,
                RelatedProductID = x.RelatedProductID

            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }
        #endregion

        #region Feature
       

        public OperationResult AddNewProductFeatureValue(ProductFeatureValue current)
        {
            OperationResult op = new OperationResult("Add ProductFeatureValue");
            try
            {
                db.ProductFeatureValues.Add(current);
                db.SaveChanges();
                return op.Succeed("Add Successfully", current.ProductFeatureValueID);
            }
            catch (Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message, current.ProductFeatureValueID);
            }
        }
        public List<ProductFeatureValue> GetProductFeatureValueByProductId(int productId)
        {
            return db.ProductFeatureValues.Where(x => x.ProductID == productId).ToList();
        }

        public List<ProductFeatureListItem> searchfeature(ProductFeatureSearchAddModel sm, out int RecordCount)
        {
            var q = from p in db.Products
                    join pf in db.ProductFeatureValues on p.ProductID equals pf.ProductID
                    join f in db.Features on pf.FeatureID equals f.FeatureID
                    select new ProductFeatureSearchJoin
                    {
                        ProductFeatureValueID = pf.ProductFeatureValueID,
                        FeatureName = f.FeatureName,
                        ProductName = p.ProductName,
                        ProductID = p.ProductID,
                        FeatureValue= pf.FeatureValue
                    };

            if (sm.ProductID != null)
            {
                q = q.Where(x => x.ProductID == sm.ProductID);
            }

            RecordCount = q.Count();
            return q.OrderByDescending(x => x.ProductFeatureValueID).Select(x => new ProductFeatureListItem
            {
                ProductName = x.ProductName,
                FeatureName = x.FeatureName,
                ProductFeatureValueID = x.ProductFeatureValueID,
                FeatureValue= x.FeatureValue

            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult AddFeature(ProductFeatureSearchAddModel model)
        {
            OperationResult op = new OperationResult("Add Product Features");
            try
            {
                var q = db.ProductFeatureValues.Add(new ProductFeatureValue
                {
                    ProductID = model.ProductID,
                    FeatureID = model.FeatureID,
                    FeatureValue= model.FeatureValue
                    
                });
                db.SaveChanges();
                return op.Succeed("Add Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message);
            }
        }

        public OperationResult DeleteFeature(int id)
        {
            OperationResult op = new OperationResult("Delete Feature", id);
            var pro = db.ProductFeatureValues.Single(x => x.ProductFeatureValueID == id);
            if (pro == null)
                return op.Failed("Product does not Exist", id);
            try
            {
                db.ProductFeatureValues.Remove(pro);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }
        }


        public List<CategoryFeature> categoryFeatureOnBaseCategoryIDForAddFeatureProduct(int CategoryID)
        {
           return db.CategoryFeatures.Where(x=>x.CategoryID==CategoryID).ToList();
        }

        public OperationResult UpdateFeature(int id, string values)
        {
           
             OperationResult op = new OperationResult("Update Feature values", id);
            try
            {
                var q = db.ProductFeatureValues.Single(x => x.ProductFeatureValueID == id);
                q.FeatureValue = values;
                db.SaveChanges();
                return op.Succeed("Update Feature values SuccessFully", id);
            }
            catch (Exception)
            {

                return op.Failed("Update Feature values Failed");
            }


        }

        public bool ExitsFeature(int FeatureID, int ProductId)
        {
            return db.ProductFeatureValues.Any(x=>x.FeatureID==FeatureID&&x.ProductID==ProductId);
        }
        #endregion
    }
}
