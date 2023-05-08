using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DataAccess.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        #region Fields

        private readonly EshopMashtiHasanContext _context;

        #endregion

        #region Ctor

        public SectionRepository(EshopMashtiHasanContext context)
        {
            _context = context;
        }

        #endregion

        #region Events

        public OperationResult AddNew(Section current)
        {
            OperationResult op = new OperationResult("Section Add");
            try
            {
                _context.Sections.Add(current);
                _context.SaveChanges();
                return op.Succeed("Add Successfully", current.ID);
            }
            catch (System.Exception ex)
            {
                return op.Failed("Add Faild" + "--->" + ex.Message, current.ID);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Section Delete");
            var adverrtisement = _context.Advertisements.FirstOrDefault(x => x.ID == id);
            if (adverrtisement == null)
            {
                return op.Failed("AdverrtisementID Is Does Not Exists", id);
            }

            _context.Advertisements.Remove(adverrtisement);
            _context.SaveChanges();
            return op.Succeed("Delete Successfully", id);
        }

        public Section Get(int id)
        {
            return _context.Sections.FirstOrDefault(x => x.ID == id);
        }

        public List<Section> GetAll()
        {
            return _context.Sections.ToList();
        }

        public OperationResult Update(Section current)
        {
            OperationResult op = new OperationResult("Update Advertisement", current.ID);
            try
            {
                _context.Sections.Attach(current);
                _context.Entry(current).State = EntityState.Modified;
                _context.SaveChanges();
                return op.Succeed("Update Successfully", current.ID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.ID);
            }
        }

        public Section GetSectionBySetctionName(string sectionName)
        {
            return _context.Sections.FirstOrDefault(x => x.EnglishName == sectionName);
        }

        #endregion
    }
}
