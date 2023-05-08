using Framework.BaseModel;
using Shopping.DomainModel.DTO.Advertisement;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface ISectionBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(SectionAddEditModel current);
        OperationResult AddNew(SectionAddEditModel current);
        SectionAddEditModel Get(int id);
        List<Section> GetAll();
        Section GetBySectionName(string sectionName);
    }
}
