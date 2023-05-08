

namespace Security.Domain.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsEmailActivated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }

    }
}
