using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Security.DataAccess.Repositories
{
    public class RoleActionRepository : IRoleActionRepository
    {
        #region Feilds
        private readonly SecurityContext db;
        #endregion

        #region Ctor
        public RoleActionRepository(SecurityContext db)
        {
            this.db = db;
        }
        #endregion

        #region Events
        public OperationResult Add(RoleActionAddModel model)
        {
            OperationResult op = new OperationResult("Add Role Action");
            try
            {
                var RA = new RoleAction
                {
                    HasPermission= model.HasPermission,
                    RoleID= model.RoleID,
                    ProjectActionID= model.ProjectActionID
                };
                db.RoleActions.Add(RA);
                db.SaveChanges();
                return op.Succeed("Add RoleAction Successfully", RA.RoleActionID);
            }
            catch (Exception ex)
            {

                return op.Failed("Add Role Action ToFail"+ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete RoleAction");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
                db.RoleActions.Remove(ra);
                db.SaveChanges();
                return op.Succeed("Delete Role Action Successfully", id);
            }
            catch (Exception ex)
            {

                return op.Failed( "Delete Role Action to Fail" + ex.Message);
            }
        }

        public RoleAction Get(int id)
        {
            return db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
        }

        public List<RoleAction> GetAll()
        {
            return db.RoleActions.ToList();
        }

        public List<ProjectActionDrop> ProjectActionDrps(int? id)
        {

            var q = from item in db.ProjectActions select item;
            if(id != -1)
            {
                q=q.Where(x=>x.ProjectControllerID== id);
            }
            return q.Select(x => new ProjectActionDrop
            {
                ProjectActionID = x.ProjectActionID,
                ProjectActionName = x.ProjectActionName
            }).ToList();
        }

        public List<RoleDrop> RoleDrps()
        {
            var q = from item in db.Roles select item;
            return q.Select(x => new RoleDrop
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();
        }

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            var q = from item in db.RoleActions select item;

            if (sm.RoleID != null)
            {
                q = q.Where(x => x.RoleID == sm.RoleID);
            }
            if (sm.RoleActionID != null)
            {
                q = q.Where(x => x.RoleActionID == sm.RoleActionID);
            }
            if (sm.ProjectActionID != null)
            {
                q = q.Where(x => x.ProjectActionID == sm.ProjectActionID);
            }
            if (sm.ProjectContorollerID != null)
            {
                q = q.Where(x => x.ProjectAction.ProjectControllerID == sm.ProjectContorollerID);
            }
            RecordCount = q.Count();
            return q.OrderByDescending(x => x.RoleActionID).Select(x => new RoleActionListItem
            {
                RoleActionID = x.RoleActionID,
                RoleName = x.Role.RoleName,
                ProjectActionName = x.ProjectAction.ProjectActionName,
                HasPermission = x.HasPermission,
                ProjectControllerName = x.ProjectAction.ProjectController.ProjectControllerName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(RoleActionUpdateModel model)
        {
            var op = new OperationResult("Update RoleAction");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == model.RoleActionID);
                ra.HasPermission=model.HasPermission;
                ra.RoleID= model.RoleID;
                ra.ProjectActionID= model.ProjectActionID;
                db.SaveChanges();
                return op.Succeed("Update RoleAction Successfuly");
            }
            catch (Exception ex)
            {
                return op.Failed("Update RoleAction Fail" + ex.Message);
            }
        }

        public List<ProjectControllerDrop> ProjectControllerDrops()
        {
            var q = from item in db.ProjectControllers select item;
            return q.Select(x => new ProjectControllerDrop
            {
                ProjectControllerID = x.ProjectControllerID,
                ProjectControllerName = x.ProjectControllerName
            }).ToList();
        }

        public bool ExitsRoleAction(int RoleID, int ActionID)
        {
            return db.RoleActions.Any(x => x.RoleID == RoleID && x.ProjectActionID == ActionID);
        }
        #endregion
    }
}
