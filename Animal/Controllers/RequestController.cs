using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Animal.Controllers
{
    // [Authorize]
    public class RequestController : Controller
    {
        private readonly IUnitOfWork _repo;
        private readonly IUserRepository _user;
        private readonly IConfiguration _config;

        public RequestController(IUnitOfWork repo, IUserRepository user, IConfiguration config)
        {
            _repo = repo;
            _user = user;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckEarTag(string earTag)
        {
            EarTag ear = _repo.EarTag.GetByTag(earTag);
            if (ear != null)
            {
                return Json("NOTNULL");
            }
            else
            {
                return Json("NULL");
            }

        }

        public JsonResult CascadeBreed(string speciesId)
        {
            IEnumerable<Breed> breeds = _repo.Breed.GetBySpecies(int.Parse(speciesId));
            SelectList BreedList = new SelectList(breeds, "id", "breedNameShort");

            return Json(BreedList);


        }

        [HttpPost]
        public JsonResult AllowAccess(string userId)
        {
            try
            {
                int id = Convert.ToInt32(userId);

                User user = _user.GetById(id);
                user.permission = !user.permission;

                _user.Update(user);

                string token = Guid.NewGuid().ToString();
                user.ResetPasswordCode = token;
                _user.Update(user);

                var resetLink = Url.Action("Login", "Account", new { }, protocol: HttpContext.Request.Scheme);

                // code to email the above link

                if (user.permission)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.IsBodyHtml = true;
                    mail.To.Add(user.Email);
                    mail.From = new MailAddress(_config.GetSection("Email:UserId").Value);
                    mail.Subject = "<h2>LIMS:Account Activated Successfully.</h2>";
                    mail.Body = "<p>Dear " + user.Name + ",you can login from here." + resetLink + "<br>Thank you.</p>";
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = _config.GetSection("Email:Host").Value;
                    smtp.Port = Convert.ToInt16(_config.GetSection("Email:SMTPPort").Value);
                    smtp.Credentials = new NetworkCredential(_config.GetSection("Email:UserId").Value, _config.GetSection("Email:Password").Value);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }





                return Json("Access Permission Changed Successfully.");
            }
            catch
            {
                return Json("Print Error.");
            }

        }
        [HttpPost]
        public JsonResult GetNutrition(string milkVolumn, string fat, string weight, string nutrition, string species)
        {
            GeneralNutration gn = _repo.GeneralNutrition.GetByWeight(weight, species);
            MIlkBaseNutrition mn = _repo.MilkBase.GetByFat(fat, milkVolumn, int.Parse(species));
            EarTag ear = _repo.EarTag.GetByTag("");
            if (ear != null)
            {
                return Json("NOTNULL");
            }
            else
            {
                return Json("NULL");
            }

        }


    }
}