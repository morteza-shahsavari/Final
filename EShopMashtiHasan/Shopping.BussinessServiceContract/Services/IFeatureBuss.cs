using Shopping.DomainModel.DTO.ProductFeature;
using Framework.BaseModel;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface IFeatureBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(Feature current);
        OperationResult AddNew(Feature current);
        Feature Get(int id);
        List<Feature> GetAll();
        List<Feature> Search(FeatureSearchModel sm, out int RecordCount);
        public List<Feature> SearchFeatureName(string search);

        
    }
}