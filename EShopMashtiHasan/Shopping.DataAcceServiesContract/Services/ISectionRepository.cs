using Framework.Shopping.Base;

using Shopping.DomainModel.Models;

namespace DataAccessServiceContract.Services
{
    public interface ISectionRepository : IBaseRepository<Section , int>
    {
        Section GetSectionBySetctionName(string sectionName);
    }
}
