using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models.ViewModel
{
    public class ChangePassword
    {
        public int  userId { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        public string newPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("newPassword")]
        public string confirmPassword { get; set; }
    }
}
