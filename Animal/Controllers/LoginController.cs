using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Repository;
using HotelManagemant;
using HotelManagemant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Areas.Admin.Models;
using SchoolInformationSystem.Data;
using SchoolInformationSystem.ViewModels;

namespace Animal.Controllers
{
    public class LoginController : Controller
    {
        private readonly AnimalContext context;
            private IAuthRepository auth;
            public LoginController()
            {
                this.auth = new AuthRepository(context);
            }
            // GET: Admin/Admins



            public ActionResult Index()
            {
                return View();
            }


            public ActionResult Login()
            {
                return View();
            }
            Role role = new Role();
            [HttpPost]
            public ActionResult Login(LoginViewModel l, string ReturnUrl)
            {

                ViewBag.ReturnUrl = ReturnUrl;


                if (auth.IsUserExists(l.Email))
                {
                    var login = auth.Login(l.Email, l.Password);

                 


                    if (login != null)
                    {
                        var Admin = context.login.FirstOrDefault(a => (a.Email == l.Email));

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            var objAdmin = context.login.FirstOrDefault(a => (a.Email == l.Email));


                    

                            return Redirect(ReturnUrl);

                        }
                        else
                        {
                          
                            var objAdmin = context.login.FirstOrDefault(a => (a.Email == l.Email));
                           
                            string[] roles = role.GetRolesForUser(objAdmin.Email);
                            if (roles.Contains("SuperAdmin"))
                            {
                                return RedirectToAction("Index", "Admin");

                            }
                            if (roles.Contains("Admin"))
                            {
                                return RedirectToAction("Index", "News");
                            }

                        }

                    }
                  


                    else
                    {
                        ModelState.AddModelError("", "Invalid Password");
                    }

                }
                ModelState.AddModelError("", "Invalid User");

                return View();


            }

            public ActionResult NewPassword()
            {

                return PartialView();

            }
            [HttpPost]
            public ActionResult NewPassword(PasswordConform pass)
            {
                if (ModelState.IsValid)
                {
                    string message = TempData["message"].ToString();
                    var query = (from q in context.login
                                 where q.Email == message
                                 select q).First();
                    string password = pass.Password;
                    Login login = auth.registers(query, password);
                    //query.RandomPass = null;

                    return RedirectToAction("Login");



                }
                return PartialView();
            }
            public ActionResult Logout()
            {


              
           
                return RedirectToAction("Login");


            }

        }
    }

}
}