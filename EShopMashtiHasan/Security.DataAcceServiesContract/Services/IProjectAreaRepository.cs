using Framework.Base;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;

namespace DataAccessServiceContract.Services
{
    public interface IProjectAreaRepository:IBaseRepositorysearchable<ProjectArea,int, ProjectAreaSearchModel, ProjectAreaListItem, ProjectAreaUpdateModel, ProjectAreaAddModel>
    {
        bool ExitsAreaName(string AreaName);
        bool ExitsAreaName(string AreaName, int ProjectAreaID);

    }
}
