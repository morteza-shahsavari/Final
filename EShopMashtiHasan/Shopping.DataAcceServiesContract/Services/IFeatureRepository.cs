
using System.Collections.Generic;
using Framework.Shopping.Base;
using Shopping.DomainModel.Models;
using Shopping.DomainModel.DTO.ProductFeature;

namespace DataAccessServiceContract.Services
{
    public interface IFeatureRepository : IBaseRepository<Feature,int>
    {
        List <Feature> Search(FeatureSearchModel sm, out int RecordCount);
        List<Feature> SearchFeatureName(string search);

        bool ExitsFeatureName(string featureName);
        bool ExitsFeatureName(string featureName, int featureID);
    }
}
