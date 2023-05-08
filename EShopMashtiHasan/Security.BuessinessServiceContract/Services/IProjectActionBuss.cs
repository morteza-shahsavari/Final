using Framework.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System.Collections.Generic;


namespace Security.BuessinessServiceContract.Services
{ 
    public interface IProjectActionBuss
    {
        OperationResult Register(ProjectActionAddModel PA);
        OperationResult update(ProjectActionUpdateModel PA);
        OperationResult Delete(int ProjectActionID);
        List<ProjectActionListItem> Search(ProjectActionSearchModel sm, out int RecordCount);
        ProjectAction GetProjectAction(int ProjectActionID);
        List<ProjectControllerDrop> ProjectControllerDrops();
        int GetProjectController(string Controller);
        OperationResult Delete();
        bool ExitsControllerActionName(int ControllerID, string ActionName);
    }
}
