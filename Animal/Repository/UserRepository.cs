using Animal.Models;
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
