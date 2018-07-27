using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTO
{
    public class UserDTO : User
    {
        public string Password { get; set; }
    }
}
