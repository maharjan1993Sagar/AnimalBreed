using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
   public interface IUserRepository
    {
        User Register(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);
    }
}
