
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DataAccess.Repositories
{
    public class AdvertisementInSectionRepository : IAdvertiseInSectionRepository
    {
        #region Fields

        private readonly EshopMashtiHasanContext _context;

        #endregion

        #region Ctor

        public AdvertisementInSectionRepository(EshopMashtiHasanContext context)
        {
            _context = context;
        }

        #endregion

        #region Events

        public OperationResult AddNew(AdvertisementInSection current)
        {
            OperationResult op = new OperationResult("AddNew AdvertisementInSectionRepository");
            try
            {
                _context.AdvertisementInSections.Add(current);
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
            var advertisementInSection = _context.AdvertisementInSections.FirstOrDefault(x => x.ID == id);
            OperationResult op = new OperationResult("Delete AdvertisementInSectionRepository");
            if (advertisementInSection == null)
            {
                op.Failed("AdverrtisementInSectionID Is Does Not Exists", id);
            }

            _context.AdvertisementInSections.Remove(advertisementInSection);
            _context.SaveChanges();
            return op.Succeed("Delete Successfully", id);
        }

        public AdvertisementInSection Get(int id)
        {
            return _context.AdvertisementInSections.FirstOrDefault(x => x.ID == id);
        }

        public List<AdvertisementInSection> GetAll()
        {
            return _context.AdvertisementInSections.ToList();
        }

        public OperationResult Update(AdvertisementInSection current)
        {
            OperationResult op = new OperationResult("Update AdvertisementInSectionRepository");
            try
            {
                _context.AdvertisementInSections.Attach(current);
                _context.Entry(current).State = EntityState.Modified;
                _context.SaveChanges();
                return op.Succeed("Update SuccessFully" , current.ID);
            }
            catch (System.Exception ex)
            {
                return op.Failed("Update Failed" + ex.Message, current.ID);
            }
        }

        public AdvertisementInSection GetByAdvertisementIdAndSectionId(int advertisementId, int sectionId) 
        {
            return _context.AdvertisementInSections.FirstOrDefault(x => x.AdvertisementId == advertisementId && x.SectionId == sectionId);
        }

        public List<AdvertisementInSection> GetBySectionId(int sectionId)
        {
            return _context.AdvertisementInSections.Where(x => x.SectionId == sectionId).Take(6).ToList();
        }

        #endregion

    }
}