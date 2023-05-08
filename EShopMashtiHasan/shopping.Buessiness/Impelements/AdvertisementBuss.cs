using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.Extensions.Hosting;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Advertisement;
using Shopping.DomainModel.Models;
using System.Collections.Generic;
using System.IO;

namespace shopping.Buessiness.Impelements
{
    public class AdvertisementBuss : IAdvertisementBuss
    {
        #region Fields

        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IHostingEnvironment _env;
        private readonly IAdvertiseInSectionRepository _advertiseInSectionRepository;

        #endregion

        #region Ctor

        public AdvertisementBuss(IAdvertisementRepository advertisementRepository,
            IHostingEnvironment env, IAdvertiseInSectionRepository advertiseInSectionRepository)
        {
            _advertisementRepository = advertisementRepository;
            _env = env;
            _advertiseInSectionRepository = advertiseInSectionRepository;
        }

        #endregion

        #region Events

        public OperationResult AddNew(AdvertisementAddEditModel current)
        {
            var advertisement = ToAdvertisement(current);
            var result = _advertisementRepository.AddNew(advertisement);
            var advertisementInsection = new AdvertisementInSection
            {
                AdvertisementId = advertisement.ID,
                SectionId = current.SectionId,
                Position = current.Position,
            };
            _advertiseInSectionRepository.AddNew(advertisementInsection);
            return result;
        }

        public OperationResult Delete(int id)
        {
            return _advertisementRepository.Delete(id);
        }

        public AdvertisementAddEditModel Get(int id)
        {
            var advertisement = _advertisementRepository.Get(id);
            return ToAddEditModel(advertisement);
        }

        public List<Advertisement> GetAll()
        {
            return _advertisementRepository.GetAll();
        }

        public OperationResult Update(AdvertisementAddEditModel current)
        {
            var advertisementAddEditModel = ToAdvertisement(current);
            return _advertisementRepository.Update(advertisementAddEditModel);
        }

        private Advertisement ToAdvertisement(AdvertisementAddEditModel advertisementAddEditModel)
        {

            var advertisement = new Advertisement
            {
                Alt = advertisementAddEditModel.Alt,
                Deleted = advertisementAddEditModel.Deleted,
                ExpireDate = advertisementAddEditModel.ExpireDate,
                ID = advertisementAddEditModel.ID,
                Picture = advertisementAddEditModel.Picture,
                link = advertisementAddEditModel.Link
            };
            return advertisement;
        }

        private AdvertisementAddEditModel ToAddEditModel(Advertisement advertisement)
        {
            FileStream fs = new FileStream(advertisement.Picture, FileMode.Open);
            var addEditModel = new AdvertisementAddEditModel
            {
                ID = advertisement.ID,
                ExpireDate = advertisement.ExpireDate,
                Deleted = advertisement.Deleted,
                Alt = advertisement.Alt,
            };
            return addEditModel;
        }

        #endregion

    }
}