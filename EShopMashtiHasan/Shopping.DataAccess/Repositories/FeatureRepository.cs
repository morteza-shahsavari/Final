using DataAccessServiceContract.Services;
using Shopping.DomainModel.DTO.ProductFeature;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DataAccess.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        #region Fields

        private readonly EshopMashtiHasanContext db;

        #endregion

        #region Ctor

        public FeatureRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }



        #endregion

        #region Events

        public OperationResult AddNew(Feature current)
        {
            OperationResult op = new OperationResult("Add Feature");
            try
            {
                db.Features.Add(current);
                db.SaveChanges();
                return op.Succeed("Add Successfully", current.FeatureID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.FeatureID);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Feature", id);
            var p = db.Features.FirstOrDefault(x => x.FeatureID == id);
            if (p == null)
                return op.Failed("FeatureID does not Exist", id);
            try
            {
                db.Features.Remove(p);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }
        }

        public bool ExitsFeatureName(string featureName)
        {
            return db.Features.Any(x => x.FeatureName == featureName);
        }

        public bool ExitsFeatureName(string featureName, int featureID)
        {
            return db.Features.Any(x => x.FeatureName == featureName&& x.FeatureID==featureID);
        }

        public Feature Get(int id)
        {
           return db.Features.FirstOrDefault(x => x.FeatureID == id);
        }

        public List<Feature> GetAll()
        {
            return db.Features.ToList();
        }

        public List<Feature> Search(FeatureSearchModel sm, out int RecordCount)
        {
           
                var q = from item in db.Features select item;
                if (!string.IsNullOrEmpty(sm.FeatureName))
                {
                    q = q.Where(x => x.FeatureName.StartsWith(sm.FeatureName));
                }

            RecordCount = q.Count();
                return q.OrderByDescending(x => x.FeatureID).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).Select(x => new Feature 
                { FeatureID = x.FeatureID, FeatureName = x.FeatureName, FeatureDescription = x.FeatureDescription }).ToList();

        }

        public List<Feature> SearchFeatureName(string search)
        {

            var q = from item in db.Features select item;
            if (!string.IsNullOrEmpty(search))
            {

                q = q.Where(x => x.FeatureName.Contains(search));
                return q.ToList();
            }

            else return q.ToList();
       

    }

        public OperationResult Update(Feature current)
        {
            OperationResult op = new OperationResult("Update Feature", current.FeatureID);
            try
            {
                db.Features.Attach(current);
                db.Entry(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Successfully", current.FeatureID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.FeatureID);
            }
        }

        #endregion

    }
}
