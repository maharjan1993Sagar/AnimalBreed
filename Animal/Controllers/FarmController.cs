using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class FarmController : Controller
    {
        private readonly IRepository<Farm> _repo;

        public FarmController(IRepository<Farm> repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<Farm> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditFarm(int? id)
        {
           Farm model = new Farm();
            if (id.HasValue)
            {
                Farm feed = _repo.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditFarm(int? id, Farm model)
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
        public IActionResult DeleteFarm(int id)
        {
            Farm feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

    }
}