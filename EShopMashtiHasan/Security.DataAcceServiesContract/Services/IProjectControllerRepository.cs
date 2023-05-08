using System.Collections.Generic;
using Framework.Base;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;

namespace DataAccessServiceContract.Services
{
    public interface IProjectControllerRepository:IBaseRepositorysearchable<ProjectController,int, ProjectControllerSearchModel, ProjectControllerListItem, ProjectControllerUpdateModel, ProjectControllerAddModel>
    {
        bool ExitsProjectControllerName(string ProjectControllerName);
        bool ExitsProjectControllerName(string ProjectControllerName, int ProjectControllerID);
        public List<ProjectAreaDrop> ProjectAreaDrps();
        public OperationResult DeleteAll();
    }
}
