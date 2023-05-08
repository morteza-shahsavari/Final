using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.ProductFeature;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace shopping.Buessiness.Impelements
{
    public class CategoryBuss : ICatBuss
    {

        #region Fields
        private readonly ICategoryRepository repo;
        #endregion
      
        #region Ctor


       
        public CategoryBuss(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        #endregion

        #region Category

        private Category ToCategory(CategoryAddEditModel c)
        {
            Category cat = new Category
            {
                CategoryID = c.CategoryID
                ,
                CategoryName = c.CategoryName
                ,
                ParentID = c.ParentID
                ,
                SmallDescription = c.SmallDescription
            };
            return cat;

        }
        private CategoryAddEditModel ToAddEditModel(Category c)
        {
            var cat = new CategoryAddEditModel
            {
                CategoryID = c.CategoryID
                ,
                ParentID = c.ParentID
                ,
                CategoryName = c.CategoryName
                ,
                SmallDescription = c.SmallDescription
            };
            return cat;
        }
        public OperationResult Delete(int id)
        {
            var cat = repo.Get(id);
            if (repo.HasChild(id))
            {
                return new OperationResult("Delete Category", id).Failed("This Category Has Related Category", id);
            }
            if (repo.HasProduct(id))
            {
                return new OperationResult("Delete Category", id).Failed("This Category Has Related Products", id);
            }
            return repo.Delete(id);
        }

        public OperationResult Update(CategoryAddEditModel current)
        {
            if (repo.DuplicateName(current.CategoryName, current.CategoryID))
            {
                OperationResult op = new OperationResult("Update").Failed("Duplicate Category Name", current.CategoryID);
                return op;
            }
            if (current.ParentID != null)//Node Root Nist
            {
                var parent = repo.Get(current.ParentID.Value);
                var ParentLineage = parent.Lineage;
                var CurrentLinage = ParentLineage + current.CategoryID + ",";
                var Depth = parent.Depth + 1;
                //Build Linage
                //Depth
                //All Children Must be Adjusted
                Category cat = ToCategory(current);
                cat.Depth = Depth;
                cat.Lineage = CurrentLinage;
                return repo.Update(cat);
            }
            else
            {
                var CurrentLinage = current.CategoryID + ",";
                var Depth = 1;

                Category cat = ToCategory(current);
                cat.Depth = Depth;
                cat.Lineage = CurrentLinage;
                return repo.Update(cat);
            }
        }

        public OperationResult AddNew(CategoryAddEditModel current)
        {
            if (repo.DuplicateName(current.CategoryName))
            {
                OperationResult op = new OperationResult("Add Category").Failed("Duplicate Category Name", null);
                return op;
            }
            if (current.ParentID != null)
            {
                var parent = repo.Get(current.ParentID.Value);

                var d = parent.Depth + 1;
                var c = ToCategory(current);
                c.Depth = d;
                var id = repo.AddNew(c).RecordID;
                c.Lineage = parent.Lineage + id + ",";
                return repo.Update(c);
            }
            else
            {

                var c = ToCategory(current);
                c.Depth = 1;
                var InsertedCategoryID = repo.AddNew(c).RecordID;
                c.Lineage = InsertedCategoryID + ",";
                return repo.Update(c);
            }
        }

        public CategoryAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Category> GetAll()
        {
            return repo.GetAll();
        }

        public CategoryComplexResult Search(CategorySearchModel sm, out int RecordCount)
        {
            return repo.Search(sm, out RecordCount);
        }

        public CategoryComplexResult GetParent(int id)
        {
            return repo.GetParent(id);
        }

        public CategoryComplexResult GetChildren(int id)
        {
            return repo.GetChildren(id);
        }

        public CategoryComplexResult GetParentList(int id)
        {
            return repo.GetParentList(id);
        }

        public bool HasProduct(int id)
        {
            return repo.HasProduct(id);
        }

        public bool HasChild(int id)
        {
            return repo.HasChild(id);
        }

        public bool DuplicateName(string CategoryName)
        {
            return repo.DuplicateName(CategoryName);
        }

        public bool DuplicateName(string CategoryName, int id)
        {
            return repo.DuplicateName(CategoryName, id);
        }

        #endregion

        #region Category Feature

        public List<FeatureListItem> GetFeature(int id)
        {
            return repo.GetFeature(id);
        }

        public OperationResult AddFeature(CategoryFeature model)
        {
            return repo.AddFeature(model);
        }

        public OperationResult DeleteFeature(int id)
        {
           return repo.DeleteFeature(id);
        }

        public List<CategoryFeatureListItem> searchfeature(CategoryFeatureSearchAddModel sm, out int RecordCount)
        {
            return repo.searchfeature(sm, out RecordCount);
        }

        public OperationResult AddAllNewFeature(int[] feature, int id)
        {

            foreach(var item in feature)
            {
                if (repo.HasDublicateFeature(item, id))
                {
                    continue;
                }
                else
                {
                    var q = new CategoryFeature
                    {
                        CategoryID = id,
                        FeatureID = item
                    };
                  repo.AddFeature(q);
                  repo.RegisterFeatureAllProduct(q);

                }
               
            }
            OperationResult op = new OperationResult("Add feature Category").Succeed("Add feature Category And Add Feature All Product");
            return op;

        }

        public bool HasDublicateFeature(int featureID, int CategoriID)
        {
            return repo.HasDublicateFeature(featureID, CategoriID);
        }

      


        #endregion
    }
}
