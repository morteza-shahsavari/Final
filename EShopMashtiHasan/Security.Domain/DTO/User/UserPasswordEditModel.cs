using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.User
{
    public class UserPasswordEditModel
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }

    }
}
