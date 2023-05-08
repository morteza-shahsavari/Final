using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.ProductFeature;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using Shopping.DomainModel.ViewModel.Categories;

namespace Shopping.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        #region Fields
        private readonly EshopMashtiHasanContext db;
        #endregion


        #region CTor
        public CategoryRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }
        #endregion


        #region Events
        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Category", id);
            var cat = db.Categories.Single(x => x.CategoryID == id);
            var catfea=db.CategoryFeatures.Where(x=>x.CategoryID== id);

            if (cat == null)
                return op.Failed("CategoryID does not Exist", id);
            
            try
            {
                if (catfea != null )
                {
                    foreach(var item in catfea)
                    {
                        db.CategoryFeatures.Remove(item);
                    }
                }
                    db.Categories.Remove(cat);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }
        }

        public OperationResult Update(Category current)
        {
            OperationResult op = new OperationResult("Update Category", current.CategoryID);
            try
            {
                db.Categories.Attach(current);
                db.Entry(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Successfully", current.CategoryID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.CategoryID);
            }
        }

        public OperationResult AddNew(Category current)
        {
            OperationResult op = new OperationResult("Add Category");
            try
            {
                db.Categories.Add(current);
                db.SaveChanges();
                return op.Succeed("Add Successfully", current.CategoryID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.CategoryID);
            }
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == id);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();

        }



        public CategoryComplexResult GetParent(int id)
        {
            List<string> err = new List<string>();
            var cat = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (cat == null)
            {
                err.Add("Invalid CategoryID Entered");
                return new CategoryComplexResult
                {
                    Errors = err
                    ,
                    MainResults = null
                };
            }

            if (cat.ParentID == null || cat.Parent == null)
            {
                err.Add("Parent Node Does not exist or ParentID is Wrong");
                return new CategoryComplexResult
                {
                    Errors = err
                    ,
                    MainResults = null
                };
            }
            List<CategoryListItem> Parents = new List<CategoryListItem>();
            CategoryListItem cli = new CategoryListItem
            {
                CategoryName = cat.Parent.CategoryName
                ,
                ParentID = cat.Parent.ParentID.Value
                ,
                ParentNames = ""
                ,
                CategoryID = cat.Parent.CategoryID
                ,
                ProductCount = cat.Parent.Products.Count
                ,
                ChildCount = cat.Children.Count
            };
            Parents.Add(cli);
            return new CategoryComplexResult
            {
                Errors = null
              ,
                MainResults = Parents
            };
        }

        public CategoryComplexResult GetChildren(int id)
        {
            List<string> errorList = new List<string>();
            CategoryComplexResult result = new CategoryComplexResult();
            var cat = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (cat == null)
            {
                errorList.Add("Invalid CategoryID");
                result.MainResults = null;
                result.Errors = errorList;
            }

            if (!cat.Children.Any())
            {
                errorList.Add("This Node Has No Children");
                result.MainResults = null;
                result.Errors = errorList;
            }

            var q = db.Categories.Where(x => x.ParentID == id).Select(x => new CategoryListItem
            {
                CategoryName = x.CategoryName,
                ParentID = x.ParentID.Value,
                ParentNames = "",
                CategoryID = x.CategoryID,
                ProductCount = x.Products.Count,
                ChildCount = x.Children.Count
            }).ToList();
          
            result.MainResults = q;
            result.Errors = null;
            return result;
        }

        public CategoryComplexResult GetParentList(int id)
        {
            return null;
        }

        public bool HasProduct(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            return cat.Products.Any();
        }

        public bool HasChild(int id)
        {
            return db.Categories.Any(x => x.ParentID == id);
        }

        public bool DuplicateName(string CategoryName)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName);
        }

        public bool DuplicateName(string CategoryName, int id)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName && x.CategoryID != id);

        }

        private IEnumerable<CategoryListItem> OrderBy(CategorySearchModel sm)
        {

            switch (sm.OrderBy)
            {
                case OrderByType.جدیدترین:
                var cat = db.Categories.Select(item => new CategoryListItem
                {
                    CategoryID = item.CategoryID,
                    CategoryName = item.CategoryName,
                    ChildCount = item.Children.Count(),
                    ParentNames = item.Parent.CategoryName,
                    ProductCount = item.Products.Count(),
                    ParentID = item.ParentID ?? 0,
                    Products = item.Products.Select(x => new ProductListItem
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        Picture1 = x.Picture1 ?? x.Picture2,
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        SupplierName = x.Supplier.SupplierName,
                        UnitPrice = x.UnitPrice,
                        IsNew = x.IsNew
                    }).Where(x => x.IsNew==true).Skip(sm.PageIndex * sm.PageSize)
                                             .Take(sm.PageSize).ToList(),
                });
            return cat;

                
                case OrderByType.ارزانترین:
                    var chip = db.Categories.Select(item => new CategoryListItem
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        ChildCount = item.Children.Count(),
                        ParentNames = item.Parent.CategoryName,
                        ProductCount = item.Products.Count(),
                        ParentID = item.ParentID ?? 0,
                        Products = item.Products.Select(x => new ProductListItem
                        {
                            CategoryID = item.CategoryID,
                            CategoryName = item.CategoryName,
                            Picture1 = x.Picture1 ?? x.Picture2,
                            ProductID = x.ProductID,
                            ProductName = x.ProductName,
                            SupplierName = x.Supplier.SupplierName,
                            UnitPrice = x.UnitPrice,
                            IsNew = x.IsNew
                        }).Where(x => x.UnitPrice < 5000000).Skip(sm.PageIndex * sm.PageSize)
                                             .Take(sm.PageSize).ToList(),
                    });
                    return chip;

            
                case OrderByType.گرانترین:
                     var Expin = db.Categories.Select(item => new CategoryListItem
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        ChildCount = item.Children.Count(),
                        ParentNames = item.Parent.CategoryName,
                        ProductCount = item.Products.Count(),
                        ParentID = item.ParentID ?? 0,
                        Products = item.Products.Select(x => new ProductListItem
                        {
                            CategoryID = item.CategoryID,
                            CategoryName = item.CategoryName,
                            Picture1 = x.Picture1 ?? x.Picture2,
                            ProductID = x.ProductID,
                            ProductName = x.ProductName,
                            SupplierName = x.Supplier.SupplierName,
                            UnitPrice = x.UnitPrice,
                            IsNew = x.IsNew
                        }).Where(x => x.UnitPrice > 5000000).Skip(sm.PageIndex * sm.PageSize)
                                             .Take(sm.PageSize).ToList(),
                    });
                    return Expin;


                default:

                    var category = db.Categories.Select(item => new CategoryListItem
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        ChildCount = item.Children.Count(),
                        ParentNames = item.Parent.CategoryName,
                        ProductCount = item.Products.Count(),
                        ParentID = item.ParentID ?? 0,
                        Products = item.Products.Select(x => new ProductListItem
                        {
                            CategoryID = item.CategoryID,
                            CategoryName = item.CategoryName,
                            Picture1 = x.Picture1 ?? x.Picture2,
                            ProductID = x.ProductID,
                            ProductName = x.ProductName,
                            SupplierName = x.Supplier.SupplierName,
                            UnitPrice = x.UnitPrice,
                            IsNew = x.IsNew
                        }).Skip(sm.PageIndex * sm.PageSize)
                                             .Take(sm.PageSize).ToList(),

                    });

                    return category;
            }

        }

        public CategoryComplexResult Search(CategorySearchModel sm, out int RecordCount)
        {

            List<string> ErrorList = new List<string>();
        

            try
            {
                var q = OrderBy(sm);
                if (!string.IsNullOrEmpty(sm.CategoryName))
                {
                    q = q.Where(x => x.CategoryName.Contains(sm.CategoryName));
                }
                if (sm.CategoryId > 0)
                {
                    q = q.Where(x => x.CategoryID == sm.CategoryId);
                }
                if (sm.ParentID != null)
                {
                    q = q.Where(x => x.ParentID == sm.ParentID);
                }
                RecordCount = q.Count();
               
                var results = new CategoryComplexResult
                {
                    Errors = null
                    ,
                    MainResults = q.ToList()
                };
                return results;
            }
            catch (Exception ex)
            {
                ErrorList.Add("خطا در بازیابی" + ex.Message);
                CategoryComplexResult results = new CategoryComplexResult
                {
                    Errors = ErrorList
                    ,
                    MainResults = null
                };
                RecordCount = 0;
                return results;

            }

        }





        public List<FeatureListItem> GetFeature(int id)
        {
            var q = from c in db.Categories
                    join cf in db.CategoryFeatures on c.CategoryID equals cf.CategoryID
                    join f in db.Features on cf.FeatureID equals f.FeatureID
                    select new FeatureListItem
                    {
                        FeatureId = cf.FeatureID,
                        FeatureName = f.FeatureName,
                        FeatureDescription = f.FeatureDescription
                    };
            return q.Where(x=>x.FeatureId==id).ToList();

                
        }
        public List<CategoryFeatureListItem> searchfeature(CategoryFeatureSearchAddModel sm,out int RecordCount)
        {
            var q = from c in db.Categories
                    join cf in db.CategoryFeatures on c.CategoryID equals cf.CategoryID
                    join f in db.Features on cf.FeatureID equals f.FeatureID
                    select new CategorySearch
                    {
                        CategoryFeatureID = cf.CategoryFeatureID,
                        FeatureName = f.FeatureName,
                        CategoryName = c.CategoryName,
                        CategoryID= cf.CategoryID,
                    };

            if (sm.CategoryID != null)
            {
                q = q.Where(x => x.CategoryID == sm.CategoryID);
            }

            RecordCount = q.Count();
            return q.OrderByDescending(x=>x.CategoryFeatureID).Select(x => new CategoryFeatureListItem
            {
                CategoryName = x.CategoryName,
                FeatureName = x.FeatureName,
                CategoryFeatureID = x.CategoryFeatureID

            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult AddFeature(CategoryFeature model)
        {
            OperationResult op = new OperationResult("Add Category Features");
            try
            {
               var q= db.CategoryFeatures.Add(new CategoryFeature
                {
                    CategoryID = model.CategoryID,
                    FeatureID =model.FeatureID
                });
            db.SaveChanges();
                return op.Succeed("Add Successfully" ,model.CategoryFeatureID);
            }
            catch (Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message);
            }
          
        }



        public OperationResult DeleteFeature(int id)
        {
         
            OperationResult op = new OperationResult("Delete Feature", id);
            var cat = db.CategoryFeatures.Single(x => x.CategoryFeatureID == id);
            if (cat == null)
                return op.Failed("CategoryID does not Exist", id);
            try
            {

                var productFeature = db.ProductFeatureValues.Where(x => x.FeatureID == cat.FeatureID && x.Product.CategoryID == cat.CategoryID);
                db.CategoryFeatures.Remove(cat);
                if (productFeature != null)
                {
                    foreach (var item in productFeature)
                    {
                        db.ProductFeatureValues.Remove(item);
                    }
                }
               
                
                db.SaveChanges();
                return op.Succeed("Delete Category Feature And All Feature Product Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }

        }

        public bool HasDublicateFeature(int featureID, int CategoriID)
        {
           return db.CategoryFeatures.Any(x=>x.FeatureID==featureID && x.CategoryID==CategoriID);
        }

        public OperationResult RegisterFeatureAllProduct(CategoryFeature model)
        {
            OperationResult op = new OperationResult("Add Feature All Product");
            
            try
            {
                var q = ProductsMemberCategory(model.CategoryID);
                if (q == null)
                {
                    return op.Succeed("NO Exits Product");
                }
                else
                {
                    foreach (var item in q)
                    {
                        var ProductFeature = db.ProductFeatureValues.Add(new ProductFeatureValue
                        {
                            ProductID = item.ProductID ,
                            FeatureID = model.FeatureID,
                            FeatureValue = ""

                        });
                    }
                }
               
                db.SaveChanges();
                return op.Succeed("Add Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message);
            }

        }

        public List<Product> ProductsMemberCategory(int categoriID)
        {
           return db.Products.Where(x=>x.CategoryID==categoriID).ToList();

        }

      






        #endregion






    }


}
