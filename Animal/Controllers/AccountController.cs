using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Animal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _user;
        private readonly IConfiguration _config;

        public AccountController(IUserRepository user,IConfiguration config )
        {
            _user = user;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user,string password)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //validate request
            user.UserName = user.UserName.ToLower();

            if (_user.UserExists(user.UserName))
            {
                return BadRequest("username already exists");
            }

            //    var userToCreate = new User {
            //        UserName =user.UserName
            //};

            var createdUser = _user.Register(user, password);
            

            // return StatusCode(201);
            ViewBag.Message = "User Created Successfully.";
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            
                return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var userFromRepo = _user.Login(username, password);

            if (userFromRepo == null)
            {
                ModelState.AddModelError(string.Empty, "Please try again with different username and passsword.");
                return View();

            }
            // return Unauthorized();

           // bool isAuthenticated = false;

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

           // isAuthenticated = true;

            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");



            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
            //    new Claim(ClaimTypes.NameIdentifier,userFromRepo.UserName.ToString())
            //};

            //var key = new SymmetricSecurityKey(Encoding
            //    .UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));


            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.Now.AddDays(1),
            //    SigningCredentials = creds
            //};

            //var tokenHandler = new JwtSecurityTokenHandler();

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            //return Ok(new
            //{
            //    token = tokenHandler.WriteToken(token)
            //});

            //return View("Index","Home");
        }
    }
}