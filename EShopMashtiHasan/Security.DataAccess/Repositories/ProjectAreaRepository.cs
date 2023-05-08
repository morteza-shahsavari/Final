using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;

namespace Security.DataAccess.Repositories
{
    public class ProjectAreaRepository : IProjectAreaRepository
    {

        #region Fileds
        private readonly SecurityContext db;
        #endregion

        #region Ctor
        public ProjectAreaRepository(SecurityContext db)
        {
            this.db = db;
        }
        #endregion

        #region Events
        public OperationResult Add(ProjectAreaAddModel model)
        {
            var op = new OperationResult("Add Area");
            try
            {
                var Ar = new ProjectArea
                {
                    AreaName= model.AreaName,
                    PersianTitle= model.PersianTitle
                };
                db.ProjectAreas.Add(Ar);
                db.SaveChanges();
                
                return op.Succeed("Add Area Successfuly", Ar.ProjectAreaID);
            }
            catch (Exception ex)
            {
                return op.Failed("Add Area Fail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Area");
            try
            {
                var A = db.ProjectAreas.FirstOrDefault(x => x.ProjectAreaID == id);
                db.ProjectAreas.Remove(A);
                db.SaveChanges();
                return op.Succeed("Delete Area Successfully", id);
            }
            catch (Exception ex)
            {

                return op.Failed("Delete Area to Fail" + ex.Message);
            }
        }

        public bool ExitsAreaName(string AreaName)
        {
            return db.ProjectAreas.Any(x => x.AreaName == AreaName);
        }

        public bool ExitsAreaName(string AreaName, int ProjectAreaID)
        {
            return db.ProjectAreas.Any(x => x.AreaName == AreaName && x.ProjectAreaID != ProjectAreaID);
        }

        public ProjectArea Get(int id)
        {
           return db.ProjectAreas.FirstOrDefault(x=>x.ProjectAreaID==id);
        }

        public List<ProjectArea> GetAll()
        {
            return db.ProjectAreas.ToList();
        }

        public List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount)
        {
            var q = from item in db.ProjectAreas select item;
            if (!string.IsNullOrEmpty(sm.AreaName))
            {
                q = q.Where(x => x.AreaName.StartsWith(sm.AreaName));
            }
   
            RecordCount = q.Count();
            return q.OrderByDescending(x=>x.ProjectAreaID).Select(x => new ProjectAreaListItem
            {
              PersianTitle=x.PersianTitle,
              ProjectAreaID=x.ProjectAreaID,
              AreaName=x.AreaName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(ProjectAreaUpdateModel model)
        {
            var op = new OperationResult("Update Area");
            try
            {
                var A = db.ProjectAreas.FirstOrDefault(x => x.ProjectAreaID == model.ProjectAreaID);
                A.AreaName=model.AreaName;
                A.PersianTitle=model.PersianTitle;
                db.SaveChanges();
                return op.Succeed("Update Area Successfuly");
            }
            catch (Exception ex)
            {

                return op.Failed("Update Area Fail" + ex.Message);
            }
        }
        #endregion
    }
}
