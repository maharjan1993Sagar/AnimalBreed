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
        public RequestController(IUnitOfWork repo)
        {
            _repo = repo;
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


    }
}