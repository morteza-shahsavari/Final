
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Advertisement;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace shopping.Buessiness.Impelements
{
    public class AdvertisementInSectionBuss : IAdvertisementInSectionBuss
    {
        #region Fields

        private readonly IAdvertiseInSectionRepository _advertisementInSectionRepository;

        #endregion

        #region Ctor

        public AdvertisementInSectionBuss(IAdvertiseInSectionRepository advertisementInSectionRepository)
        {
            _advertisementInSectionRepository = advertisementInSectionRepository;
        }

        #endregion

        #region Events

        public OperationResult AddNew(AdvertisementInSectionAddEditModel current)
        {
            var advertisementInSection = ToAdvertisementInSection(current);
            return _advertisementInSectionRepository.AddNew(advertisementInSection);
        }

        public OperationResult Delete(int id)
        {
            return _advertisementInSectionRepository.Delete(id);
        }

        public AdvertisementInSectionAddEditModel Get(int id)
        {
            var ads = _advertisementInSectionRepository.Get(id);
            var adsAddEditModel = ToAddEditModel(ads);
            return adsAddEditModel;
        }

        public List<AdvertisementInSection> GetAll()
        {
          return  _advertisementInSectionRepository.GetAll();
        }

        public OperationResult Update(AdvertisementInSectionAddEditModel current)
        {
            var advertisementInSection = ToAdvertisementInSection(current);
            return _advertisementInSectionRepository.Update(advertisementInSection);
        }

        public AdvertisementInSection GetByAdvertisementIdAndSectionId(int advertisementId, int sectionId) 
        {
            return _advertisementInSectionRepository.GetByAdvertisementIdAndSectionId(advertisementId, sectionId);
        }

        private AdvertisementInSection ToAdvertisementInSection(AdvertisementInSectionAddEditModel sectionAddEditModel)
        {
            var advertisementInSection = new AdvertisementInSection
            {
               AdvertisementId = sectionAddEditModel.AdvertisementId,
               ID = sectionAddEditModel.ID,
               SectionId = sectionAddEditModel.SectionId,
               ResourceTitle = sectionAddEditModel.ResourceTitle,
               ResourceId = sectionAddEditModel.ResourceId,
               Position = sectionAddEditModel.Position,
            };
            return advertisementInSection;
        }

        private AdvertisementInSectionAddEditModel ToAddEditModel(AdvertisementInSection section)
        {
            var addEditModel = new AdvertisementInSectionAddEditModel
            {
                AdvertisementId = section.AdvertisementId,
                Position = section.Position,
                ResourceId = section.ResourceId,
                ResourceTitle = section.ResourceTitle,
                SectionId = section.SectionId,
                ID = section.SectionId,
            };
            return addEditModel;
        }

        public List<AdvertisementInSection> GetBySectionId(int sectionId)
        {
            return _advertisementInSectionRepository.GetBySectionId(sectionId);
        }

        #endregion

    }
}