﻿using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.User
{
    public class UserAddModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsEmailActivated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }

    }
}
