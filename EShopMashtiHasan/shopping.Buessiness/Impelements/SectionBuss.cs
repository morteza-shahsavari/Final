

using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Advertisement;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace shopping.Buessiness.Impelements
{
    public class SectionBuss : ISectionBuss
    {
        #region Fields

        private readonly ISectionRepository _sectionRepo;

        #endregion

        #region Ctor

        public SectionBuss(ISectionRepository sectionRepo)
        {
            _sectionRepo = sectionRepo;
        }

        #endregion

        #region Events

        public OperationResult AddNew(SectionAddEditModel current)
        {
            var section = ToSection(current);
            return _sectionRepo.AddNew(section);
        }

        public OperationResult Delete(int id)
        {
            return _sectionRepo.Delete(id);
        }

        public SectionAddEditModel Get(int id)
        {
            var Section = _sectionRepo.Get(id);
            return ToAddEditModel(Section);
        }

        public List<Section> GetAll()
        {
            return _sectionRepo.GetAll();
        }

        public OperationResult Update(SectionAddEditModel current)
        {
           var section = ToSection(current);
            return _sectionRepo.Update(section);
        }

        public Section GetBySectionName(string sectionName) 
        {
           return _sectionRepo.GetSectionBySetctionName(sectionName);
        }

        private Section ToSection(SectionAddEditModel sectionAddEditModel)
        {
            var section = new Section
            {
                ControllerName = sectionAddEditModel.ControllerName,
                EnglishName = sectionAddEditModel.EnglishName,
                FarsiName = sectionAddEditModel.FarsiName,
            };
            return section;
        }

        private SectionAddEditModel ToAddEditModel(Section section)
        {
            var addEditModel = new SectionAddEditModel
            {
                ControllerName = section.ControllerName,
                EnglishName = section.EnglishName,
                FarsiName = section.FarsiName,
                SectionID = section.ID
            };
            return addEditModel;
        }

        #endregion

    }
}
