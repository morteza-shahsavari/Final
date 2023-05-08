using System.Collections.Generic;
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;

namespace Security.Buessiness.Impelements
{
    public class ProjectAreaBuss : IProjectAreaBuss
    {
        private readonly IProjectAreaRepository repo;
        public ProjectAreaBuss(IProjectAreaRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Delete(int ProjectAreaID)
        {
            return repo.Remove(ProjectAreaID);
        }

        public ProjectArea GetProjectArea(int ProjectAreaID)
        {
            return repo.Get(ProjectAreaID);
        }

        public OperationResult Register(ProjectAreaAddModel Area)
        {

            if (repo.ExitsAreaName(Area.AreaName))
            {
                return new OperationResult("Update Project Area")
                      .Failed("Project Area Name Already Exist");
            }
            return repo.Add(Area);
        }

        public List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(ProjectAreaUpdateModel Area)
        {
            if (repo.ExitsAreaName(Area.AreaName, Area.ProjectAreaID))
            {
                return new OperationResult("Update Project Area")
                      .Failed("Project Area Name Already Exist");
            }
            return repo.Update(Area);
        }
    }
}
