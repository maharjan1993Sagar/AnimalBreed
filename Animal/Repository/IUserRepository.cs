using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
   public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Register(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);
        User GetById(int id);
        User GetByName(string name);
        User ChangePassword(User user, string password);
        void Delete(int id);
        void Update(User Model);
        void Save();
    }
}
