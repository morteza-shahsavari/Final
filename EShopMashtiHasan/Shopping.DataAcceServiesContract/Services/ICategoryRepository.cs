using Framework.BaseModel;
using Framework.Shopping.Base;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.ProductFeature;
using Shopping.DomainModel.Models;
using System.Collections.Generic;
using CategoryFeature = Shopping.DomainModel.Models.CategoryFeature;

namespace DataAccessServiceContract.Services
{
   public interface ICategoryRepository:IBaseRepositorySearchable<Category,int,CategorySearchModel,Shopping.DomainModel.DTO.Category.CategoryComplexResult>
   {
    
        CategoryComplexResult GetParent(int id);
       CategoryComplexResult GetChildren(int id);
       CategoryComplexResult GetParentList(int id);
       bool HasProduct(int id);
       bool HasChild(int id);
       bool DuplicateName(string CategoryName);
       bool DuplicateName(string CategoryName,int id);
        
        List<FeatureListItem> GetFeature(int id);

        OperationResult AddFeature(CategoryFeature model);
        OperationResult DeleteFeature(int id);
        List<CategoryFeatureListItem> searchfeature(CategoryFeatureSearchAddModel sm, out int RecordCount);
        bool HasDublicateFeature(int featureID, int CategoriID);


        OperationResult RegisterFeatureAllProduct(CategoryFeature model);
        List<Product>ProductsMemberCategory(int categoriID);

    }
}
