using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal.Controllers
{
   // [Authorize]
    public class GeneralNutritionController : Controller
    {
        private readonly IUnitOfWork _repo;

        public GeneralNutritionController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<GeneralNutration> all = _repo.GeneralNutrition.GetModel();
            return View(all);
        }


        public IActionResult Details(int id)
        {
            GeneralNutration farm = _repo.GeneralNutrition.GetById(id);
            return View(farm);
        }
        [HttpGet]
        public IActionResult AddEditGeneralNutrition(int? id)
        {
            GeneralNutration model = new GeneralNutration();
            
            ViewBag.Species = new SelectList(_repo.Species.GetModel(), "id", "speciesName");
            if (id.HasValue)
            {
                GeneralNutration feed = _repo.GeneralNutrition.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditGeneralNutrition(int? id, GeneralNutration model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;

                    if (isNew)
                    {
                        _repo.GeneralNutrition.Insert(model);
                        _repo.Save();
                    }
                    else
                    {

                        _repo.GeneralNutrition.Update(model);
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
        public IActionResult DeleteGeneralNutrition(int id)
        {
            GeneralNutration feed = _repo.GeneralNutrition.GetById(id);
            _repo.GeneralNutrition.Delete(id);

            return RedirectToAction("Index");

        }
    }
}