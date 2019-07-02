using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IUnitOfWork _repo;
        private readonly IUserRepository _user;
        public RequestController(IUnitOfWork repo,IUserRepository user)
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
        [HttpPost]
        public JsonResult GetNutrition(string milkVolumn, string fat, string weight, string nutrition,string species)
        {
            GeneralNutration gn = _repo.GeneralNutrition.GetByWeight(weight,species);
            MIlkBaseNutrition mn = _repo.MilkBase.GetByFat(fat, milkVolumn,int.Parse(species));
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