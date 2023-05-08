using Framework.BaseModel;
using Shopping.DomainModel.DTO.Advertisement;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface IAdvertisementBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(AdvertisementAddEditModel current);
        OperationResult AddNew(AdvertisementAddEditModel current);
        AdvertisementAddEditModel Get(int id);
        List<Advertisement> GetAll();
    }
}