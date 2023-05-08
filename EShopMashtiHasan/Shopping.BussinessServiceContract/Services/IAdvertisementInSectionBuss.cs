using Framework.BaseModel;
using Shopping.DomainModel.DTO.Advertisement;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface IAdvertisementInSectionBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(AdvertisementInSectionAddEditModel current);
        OperationResult AddNew(AdvertisementInSectionAddEditModel current);
        AdvertisementInSectionAddEditModel Get(int id);
        List<AdvertisementInSection> GetAll();
        AdvertisementInSection GetByAdvertisementIdAndSectionId(int advertisementId , int sectionId);
        List<AdvertisementInSection> GetBySectionId(int sectionId);
    }
}