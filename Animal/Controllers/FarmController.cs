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
        private readonly IUnitOfWork _repo;

        public FarmController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<Farm> all = _repo.Farm.GetModel();
            return View(all);
        }


        public IActionResult Details(int id)
        {
            Farm farm = _repo.Farm.GetById(id);
            return View(farm);
        }
        [HttpGet]
        public IActionResult AddEditFarm(int? id)
        {
            Farm model = new Farm();
            if (id.HasValue)
            {
                Farm feed = _repo.Farm.GetById(id.Value);
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
                        _repo.Farm.Insert(model);
                        _repo.Save();
                    }
                    else
                    {

                        _repo.Farm.Update(model);
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
            Farm feed = _repo.Farm.GetById(id);
            _repo.Farm.Delete(id);

            return RedirectToAction("Index");

        }

    }
}