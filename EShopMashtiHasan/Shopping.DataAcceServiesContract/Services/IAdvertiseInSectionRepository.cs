
using Framework.Shopping.Base;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace DataAccessServiceContract.Services
{
    public interface IAdvertiseInSectionRepository : IBaseRepository<AdvertisementInSection, int>
    {
        AdvertisementInSection GetByAdvertisementIdAndSectionId(int advertisementId, int sectionId);
        List<AdvertisementInSection> GetBySectionId(int sectionId);
    }
}
