using Framework.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using System.Collections.Generic;

namespace Security.BuessinessServiceContract.Services
{
    public interface IProjectAreaBuss
    {
        OperationResult Register(ProjectAreaAddModel Area);
        OperationResult update(ProjectAreaUpdateModel Area);
        OperationResult Delete(int ProjectAreaID);
       
        List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount);
        ProjectArea GetProjectArea(int ProjectAreaID);
    }
}
