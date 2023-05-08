using Framework.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System.Collections.Generic;


namespace Security.BuessinessServiceContract.Services
{
    public interface IProjectControllerBuss
    {
        OperationResult Register(ProjectControllerAddModel cont);
        OperationResult update(ProjectControllerUpdateModel cont);
        OperationResult Delete(int ProjectControllerID);
        List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount);
        ProjectController GetProjectController(int ProjectControllerID);
        List<ProjectAreaDrop> ProjectAreaDrps();
        OperationResult Delete();
    }
}
