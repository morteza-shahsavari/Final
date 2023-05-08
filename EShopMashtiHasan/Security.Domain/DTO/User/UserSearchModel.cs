using Framework.BaseModel;


namespace Security.Domain.DTO.User
{
    public class UserSearchModel:PageModel
    {
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleID { get; set; }

    }
}
