using Framework.Base;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System.Collections.Generic;

namespace DataAccessServiceContract.Services
{
    public interface IProjectActionRepository:IBaseRepositorysearchable<ProjectAction,int,ProjectActionSearchModel,ProjectActionListItem,ProjectActionUpdateModel,ProjectActionAddModel>
    {
        bool ExitsProjectActionName(string ProjectActionName);
        bool ExitsProjectActionName(string ProjectActionName, int ProjectActionID);
        public List<ProjectControllerDrop> ProjectControllerDrps();
        int GetProjectController(string Controller);
        public OperationResult DeleteAll();
        bool ExitsControllerActionName(int ControllerID, string ActionName);
    }
}
