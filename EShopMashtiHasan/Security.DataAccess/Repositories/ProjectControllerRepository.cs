using Security.DataAcceServiesContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessServiceContract.Services;

using Security.Domain.Models;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.ProjectArea;
using System.Reflection.Metadata;

namespace Security.DataAccess.Repositories
{
    public class ProjectControllerRepository : IProjectControllerRepository
    {
        #region Felids
        private readonly SecurityContext db;
        #endregion

        #region Ctor
        public ProjectControllerRepository(SecurityContext db)
        {
            this.db = db;
        }
        #endregion

        #region Events
        public OperationResult Add(ProjectControllerAddModel model)
        {
            OperationResult op = new OperationResult("Add Controller");
            try
            {
                var cont = new ProjectController
                {
                    ProjectControllerName= model.ProjectControllerName,
                    PersianTitle= model.PersianTitle,
                    ProjectAreaID= model.ProjectAreaID,
                };
                db.ProjectControllers.Add(cont);
                db.SaveChanges();
               
                return op.Succeed("Add controller Successfuly", cont.ProjectControllerID);
            }
            catch (Exception ex)
            {

             return   op.Failed("Add Controller Fail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Controller");
            try
            {
                var cont = db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerID == id);
                db.ProjectControllers.Remove(cont);
                db.SaveChanges();
                return op.Succeed("Delete Controller Successfully", id);
            }
            catch (Exception ex)
            {

                return op.Failed( "Delete Controller to Fail" + ex.Message);
            }
        }

        public bool ExitsProjectControllerName(string ProjectControllerName)
        {
            return db.ProjectControllers.Any(x => x.ProjectControllerName == ProjectControllerName );
        }

        public bool ExitsProjectControllerName(string ProjectControllerName, int ProjectControllerID)
        {
            return db.ProjectControllers.Any(x => x.ProjectControllerName == ProjectControllerName && x.ProjectControllerID != ProjectControllerID);
        }

        public ProjectController Get(int id)
        {
            return db.ProjectControllers.First(x => x.ProjectControllerID == id);
        }

        public List<ProjectController> GetAll()
        {
            return db.ProjectControllers.ToList();
        }

        public List<ProjectAreaDrop> ProjectAreaDrps()
        {
            var q = from item in db.ProjectAreas select item;
            return q.Select(x => new ProjectAreaDrop
            {
                ProjectAreaID = x.ProjectAreaID,
                AreaName = x.AreaName
            }).ToList();
        }
        
        public OperationResult Update(ProjectControllerUpdateModel model)
        {
            var op = new OperationResult("Update Controller");
            try
            {
                var cont = db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerID == model.ProjectControllerID);
               cont.ProjectAreaID=model.ProjectAreaID;
                cont.ProjectControllerName=model.ProjectControllerName;
                cont.PersianTitle=model.PersianTitle;
                db.SaveChanges();
                return op.Succeed("Update Controller Successfuly");
            }
            catch (Exception ex)
            {

                return op.Failed("Update Controller Fail" + ex.Message);
            }
        }

        public List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount)
        {
            //db.ProjectControllers
            var q = from item in db.ProjectControllers select item;
            if (!string.IsNullOrEmpty(sm.ProjectControllerName))
            {
                q = q.Where(x => x.ProjectControllerName.StartsWith(sm.ProjectControllerName));
            }
            if (sm.ProjectControllerID != null)
            {
                q = q.Where(x => x.ProjectControllerID == sm.ProjectControllerID);
            }
            if (sm.ProjectAreaID != null)
            {
                q = q.Where(x => x.ProjectAreaID == sm.ProjectAreaID);
            }
            RecordCount = q.Count();
            var b= q.OrderByDescending(x=>x.ProjectControllerID).Select(x => new ProjectControllerListItem
            {
                ProjectControllerID = x.ProjectControllerID,
                ProjectControllerName = x.ProjectControllerName,
                PersianTitle = x.PersianTitle,
                AreaName =""//x.ProjectArea.AreaName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
            var c = b;
            return c;

        }

        public OperationResult DeleteAll()
        {
            var q= db.ProjectControllers.ToList();
            foreach (var item in q)
            {
                db.ProjectControllers.Remove(item);
                db.SaveChanges();
            }
          return   new OperationResult ("DeleteAll").Succeed("SuccessFully");
        }
#endregion
    }
}
