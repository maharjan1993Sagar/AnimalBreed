using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Models.ViewModel;
using Animal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal.Controllers
{
    // [Authorize]
    public class RequestController : Controller
    {
        private readonly IUnitOfWork _repo;
        private readonly IUserRepository _user;
        public RequestController(IUnitOfWork repo, IUserRepository user)
        {
            _repo = repo;
            _user = user;
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
                return Json("Access Permission Changed Successfully.");
            }
            catch
            {
                return Json("Print Error.");
            }

        }
        [HttpGet]
        public JsonResult GetNutrition(string pregnancyStatus, string milkStatus, string speciesId, string milkVolumn, string fat,string animalWeight)
        {
            GeneralNutration gn = _repo.GeneralNutrition.GetByWeight(animalWeight, speciesId);
            MIlkBaseNutrition mn = _repo.MilkBase.GetByFat(fat, milkVolumn, int.Parse(speciesId));
            PregnancyBaseNutrition pn = _repo.PregnancyBaseNutrition.GetModel().FirstOrDefault(m => m.weight == animalWeight && m.speciesId == int.Parse(speciesId)&&m.PregrenencyType==pregnancyStatus);
            requiredNutrients required = new requiredNutrients();

            required.dm = (gn.dm??"0");
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
            if ((milkVolumn ?? "0")=="0")
            {
                milkVolumn = "1";
            }
           {
                required.dm = (Convert.ToDecimal(required.dm) * Convert.ToDecimal(milkVolumn)).ToString();
                required.snf = (Convert.ToDecimal(required.snf) * Convert.ToDecimal(milkVolumn)).ToString();
                required.tdn = (Convert.ToDecimal(required.tdn) * Convert.ToDecimal(milkVolumn)).ToString();
                required.c = (Convert.ToDecimal(required.c) * Convert.ToDecimal(milkVolumn)).ToString();
                required.p = (Convert.ToDecimal(required.p) * Convert.ToDecimal(milkVolumn)).ToString();

            }
            return Json(required);


        }


    }
}