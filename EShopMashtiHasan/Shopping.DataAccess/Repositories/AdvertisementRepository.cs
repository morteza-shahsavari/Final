using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DomainModel.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        #region Fields

        private readonly EshopMashtiHasanContext _context;

        #endregion

        #region Ctor

        public AdvertisementRepository(EshopMashtiHasanContext context)
        {
            _context = context;
        }

        #endregion

        #region Events

        public OperationResult AddNew(Advertisement current)
        {
            OperationResult op = new OperationResult("Advertisement Add");
            try
            {
                _context.Advertisements.Add(current);
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
            OperationResult op = new OperationResult("Advertisement Delete");
            var adverrtisement = _context.Advertisements.FirstOrDefault(x => x.ID == id);
            if (adverrtisement == null)
            {
                return op.Failed("AdverrtisementID Is Does Not Exists", id);
            }

            _context.Advertisements.Remove(adverrtisement);
            _context.SaveChanges();
            return op.Succeed("Delete Successfully", id);
        }

        public Advertisement Get(int id)
        {
            return _context.Advertisements.FirstOrDefault(x => x.ID == id);
        }

        public List<Advertisement> GetAll()
        {
            return _context.Advertisements.ToList();
        }

        public OperationResult Update(Advertisement current)
        {
            OperationResult op = new OperationResult("Update Advertisement", current.ID);
            try
            {
                _context.Advertisements.Attach(current);
                _context.Entry(current).State = EntityState.Modified;
                _context.SaveChanges();
                return op.Succeed("Update Successfully", current.ID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.ID);
            }
        }

        #endregion
    }
}
