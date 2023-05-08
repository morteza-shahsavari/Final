﻿using Framework.BaseModel;
using Security.BuessinessServiceContract.BusinessModel.RoleAction;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System.Collections.Generic;


namespace Security.BuessinessServiceContract.Services
{
    public interface IRoleActionBuss
    {
        OperationResult Register(RoleActionViewModel RoleAction);
        OperationResult update(RoleActionUpdateModel RoleAction);
        OperationResult Delete(int RoleActionID);
        List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount);
        RoleAction GetRoleAction(int RoleActionID);
        List<RoleDrop> RoleDrps();
        List<ProjectActionDrop> ProjectActionDrps(int? id);
        List<ProjectControllerDrop> ProjectControllerDrops();


    }
}
