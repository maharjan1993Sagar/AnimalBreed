using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class OwnerKeeperController : Controller
    {
        private readonly IRepository<OwnerKeeper> _repo;

        public OwnerKeeperController(IRepository<OwnerKeeper> repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<OwnerKeeper> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditOwnerKeeper(int? id)
        {
            OwnerKeeper model = new OwnerKeeper();
            if (id.HasValue)
            {
                OwnerKeeper feed = _repo.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditOwnerKeeper(int? id, OwnerKeeper model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    
                    if (isNew)
                    {
                        _repo.Insert(model);
                        _repo.Save();
                    }
                    else
                    {
                       
                        _repo.Update(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteOwnerKeeper(int id)
        {
            OwnerKeeper feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

    }
}