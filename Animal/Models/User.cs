using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public bool permission { get; set; }
        //public bool emailConfirmation { get; set; }
        public string ResetPasswordCode { get; set; }
    }
}
