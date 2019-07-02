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
    //[Authorize]
    public class SpeciesController : Controller
    {
        private readonly IUnitOfWork _repo;

        public SpeciesController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<Species> all = _repo.Species.GetModel();
            return View(all);
        }


        public IActionResult Details(int id)
        {
            Species farm = _repo.Species.GetById(id);
            return View(farm);
        }
        [HttpGet]
        public IActionResult AddEditSpecies(int? id)
        {
            Species model = new Species();
            if (id.HasValue)
            {
                Species feed = _repo.Species.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditSpecies(int? id, Species model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;

                    if (isNew)
                    {
                        _repo.Species.Insert(model);
                        _repo.Save();
                    }
                    else
                    {

                        _repo.Species.Update(model);
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
        public IActionResult DeleteSpecies(int id)
        {
            Species feed = _repo.Species.GetById(id);
            _repo.Species.Delete(id);

            return RedirectToAction("Index");

        }
    }
}