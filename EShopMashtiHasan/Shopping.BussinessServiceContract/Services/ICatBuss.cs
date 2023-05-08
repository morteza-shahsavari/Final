using Framework.BaseModel;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.ProductFeature;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface ICatBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(CategoryAddEditModel current);
        OperationResult AddNew(CategoryAddEditModel current);
        CategoryAddEditModel Get(int id);
      
        List<Category> GetAll();
        CategoryComplexResult Search(CategorySearchModel sm, out int RecordCount);
        CategoryComplexResult GetParent(int id);
        CategoryComplexResult GetChildren(int id);
        CategoryComplexResult GetParentList(int id);
        bool HasProduct(int id);
        bool HasChild(int id);
        bool DuplicateName(string CategoryName);
        bool DuplicateName(string CategoryName, int id);
      



        List<FeatureListItem> GetFeature(int id);
        OperationResult AddFeature(CategoryFeature model);
        OperationResult DeleteFeature(int id);
        List<CategoryFeatureListItem> searchfeature(CategoryFeatureSearchAddModel sm, out int RecordCount);



        OperationResult AddAllNewFeature(int[] feature, int id);
        bool HasDublicateFeature(int featureID, int CategoriID);


    }
}