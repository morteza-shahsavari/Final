using DataAccessServiceContract.Services;
using Shopping.DomainModel.DTO.ProductFeature;
using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace shopping.Buessiness.Impelements
{
    public class FeatureBuss : IFeatureBuss
    {
        #region Fields

        private readonly IFeatureRepository _featureRepository;

        #endregion

        #region Ctor

        public FeatureBuss(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        #endregion

        #region Events

        public OperationResult AddNew(Feature current)
        {
            if (_featureRepository.ExitsFeatureName(current.FeatureName))
            {
                return new OperationResult("Register Feature")
                      .Failed("Feature name Already Exist");
            }
            return _featureRepository.AddNew(current);
        }

        public OperationResult Delete(int id)
        {
           return _featureRepository.Delete(id);
        }

        public Feature Get(int id)
        {
            return _featureRepository.Get(id);
        }

        public List<Feature> GetAll()
        {
            return _featureRepository.GetAll();
        }

        public List<Feature> Search(Shopping.DomainModel.DTO.ProductFeature.FeatureSearchModel sm, out int RecordCount)
        {
            return _featureRepository.Search(sm, out RecordCount);
        }

        public List<Feature> SearchFeatureName(string search)
        {
           return _featureRepository.SearchFeatureName(search);
        }

        public OperationResult Update(Feature current)
        {
            if (_featureRepository.ExitsFeatureName(current.FeatureName, current.FeatureID))
            {
                return new OperationResult("update Feature")
                      .Failed("Feature name and FeatureID Already Exist");
            }
            return _featureRepository.Update(current);
        }

        #endregion

    }
}