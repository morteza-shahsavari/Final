using Framework.BaseModel;


namespace Security.Domain.DTO.RoleAction
{
    public class RoleActionSearchModel:PageModel
    {
       
        public int? RoleActionID { get; set; }
        public int? RoleID { get; set; }
        public int? ProjectActionID { get; set; }
        public int? ProjectContorollerID { get; set; }
    }
}
