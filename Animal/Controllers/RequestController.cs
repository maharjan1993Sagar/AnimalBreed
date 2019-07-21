using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Models.ViewModel;
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


        [HttpPost]
        public JsonResult CheckEarTagUsed(string earTag)
        {
            AnimalRegistration ear = _repo.AnimalRegistration.GetByEartag(earTag);
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
        [HttpGet]
        public JsonResult GetNutrition(string pregnancyStatus, string milkStatus, string speciesId, string milkVolumn, string fat, string animalWeight)
        {
            GeneralNutration gn = _repo.GeneralNutrition.GetByWeight(animalWeight, speciesId);
            MIlkBaseNutrition mn = _repo.MilkBase.GetByFat(fat, int.Parse(speciesId));
            PregnancyBaseNutrition pn = _repo.PregnancyBaseNutrition.GetModel().FirstOrDefault(m => m.weight == animalWeight && m.speciesId == int.Parse(speciesId) && m.PregrenencyType == pregnancyStatus);
            requiredNutrients required = new requiredNutrients();

            required.dm = (gn.dm ?? "0");
            required.snf = (gn.snf ?? "0");
            required.tdn = (gn.tdn ?? "0");
            required.c = (gn.c ?? "0");
            required.p = (gn.p ?? "0");
            if (gn != null)
            {
                required.dm = gn.dm;
                required.snf = gn.snf;
                required.tdn = gn.tdn;
                required.c = gn.c;
                required.p = gn.p;
            }

            if (mn != null)
            {
                required.dm = (Convert.ToDecimal(required.dm) + Convert.ToDecimal(mn.dm)).ToString();
                required.snf = (Convert.ToDecimal(required.snf) + Convert.ToDecimal(mn.snf)).ToString();
                required.tdn = (Convert.ToDecimal(required.tdn) + Convert.ToDecimal(mn.tdn)).ToString();
                required.c = (Convert.ToDecimal(required.c) + Convert.ToDecimal(mn.c)).ToString();
                required.p = (Convert.ToDecimal(required.p) + Convert.ToDecimal(mn.p)).ToString();

            }

            if (pn != null)
            {
                required.dm = (Convert.ToDecimal(required.dm) + Convert.ToDecimal(pn.dm)).ToString();
                required.snf = (Convert.ToDecimal(required.snf) + Convert.ToDecimal(pn.snf)).ToString();
                required.tdn = (Convert.ToDecimal(required.tdn) + Convert.ToDecimal(pn.tdn)).ToString();
                required.c = (Convert.ToDecimal(required.c) + Convert.ToDecimal(pn.c)).ToString();
                required.p = (Convert.ToDecimal(required.p) + Convert.ToDecimal(pn.p)).ToString();

            }
            if ((milkVolumn ?? "0") == "0")
            {
                milkVolumn = "1";
            }
            {
                required.dm = (Convert.ToDecimal(required.dm) * Convert.ToDecimal(milkVolumn)).ToString();
                required.snf = (Convert.ToDecimal(required.snf) * Convert.ToDecimal(milkVolumn)).ToString();
                required.tdn = (Convert.ToDecimal(required.tdn) * Convert.ToDecimal(milkVolumn)).ToString();
                required.c = (Convert.ToDecimal(required.c) * Convert.ToDecimal(milkVolumn) * Convert.ToDecimal(1000)).ToString();
                required.p = (Convert.ToDecimal(required.p) * Convert.ToDecimal(milkVolumn) * Convert.ToDecimal(1000)).ToString();

            }
            return Json(required);


        }
        [HttpGet]
        public JsonResult GetMilkBaseNutrient(string pregnancyStatus, string milkStatus, string speciesId, string milkVolumn, string fat, string animalWeight)
        {
            //GeneralNutration gn = _repo.GeneralNutrition.GetByWeight(animalWeight, speciesId);
            MIlkBaseNutrition mn = _repo.MilkBase.GetByFat(fat, int.Parse(speciesId));
            //PregnancyBaseNutrition pn = _repo.PregnancyBaseNutrition.GetModel().FirstOrDefault(m => m.weight == animalWeight && m.speciesId == int.Parse(speciesId) && m.PregrenencyType == pregnancyStatus);
            requiredNutrients required = new requiredNutrients();

            //required.dm = (gn.dm ?? "0");
            //required.snf = (gn.snf ?? "0");
            //required.tdn = (gn.tdn ?? "0");
            //required.c = (gn.c ?? "0");
            //required.p = (gn.p ?? "0");
            //if (gn != null)
            //{
            //    required.dm = gn.dm;
            //    required.snf = gn.snf;
            //    required.tdn = gn.tdn;
            //    required.c = gn.c;
            //    required.p = gn.p;
            //}

            if (mn != null)
            {
                string[] res = CalculateDm(animalWeight, pregnancyStatus, milkVolumn);
                required.dm = res[0];
                required.snf = ( Convert.ToDecimal(mn.snf)).ToString();
                required.tdn = ( Convert.ToDecimal(mn.tdn)).ToString();
                required.c = (Convert.ToDecimal(mn.c)).ToString();
                required.p = (Convert.ToDecimal(mn.p)).ToString();
                required.message = res[1];

            }

            
            //if ((milkVolumn ?? "0") == "0")
            //{
            //    milkVolumn = "10";
            //}
            //{
            //    required.dm = (Convert.ToDecimal(required.dm)).ToString();
            //    required.snf = (Convert.ToDecimal(required.snf)).ToString();
            //    required.tdn = (Convert.ToDecimal(required.tdn) ).ToString();
            //    required.c = (Convert.ToDecimal(required.c)).ToString();
            //    required.p = (Convert.ToDecimal(required.p)).ToString();

            //}
            return Json(required);


        }

        public string[] CalculateDm(string weight,string pregnancy,string milkVolumn)
        {
            decimal wt = Convert.ToDecimal(weight);
            decimal vol = Convert.ToDecimal(milkVolumn);
            string[] result = new string[2];
            string dm = "0";

            if (vol <= 5)
            {
                dm = (Convert.ToDecimal(0.03) * wt).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 40% of DM";
            }
            else if (vol > 5 && vol <= 10)
            {
                dm = (Convert.ToDecimal(0.03) * wt ).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 50% of DM";
            }
            else if (vol > 10 && vol <= 15)
            {
                dm = (Convert.ToDecimal(0.03) * wt ).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 60% of DM";

            }
            else if (vol > 15 && vol <= 50)
            {
                dm = (Convert.ToDecimal(0.03) * wt ).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 70% of DM";
            }
            else if(vol>50)
            {
                dm = (Convert.ToDecimal(0.03) * wt ).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 70% of DM";
            }




            return result;
        }


    }
}