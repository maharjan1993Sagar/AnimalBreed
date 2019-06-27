using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AnimalContext _context;
        public UserRepository(AnimalContext Context) 
        {
            _context = Context;   
        }
        public void Delete(int id)
        {
            User model = _context.Users.Find(id);
            _context.Users.Remove(model);
            Save();
        }



        public User GetById(int id)
        {
            return _context.Users.Find(id);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User Model)
        {
            _context.Entry(Model).State = EntityState.Modified;
            Save();
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(c=>c.UserName==username);

            if(user==null)
            return null;

            if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt)) return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
              
            }
            return true;

        }

        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        public bool UserExists(string username)
        {
            if (_context.Users.Any(m => m.UserName == username)) return true;

            return false;
        }


    }
}
