using System;
using System.Collections.Generic;
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
    public class PregnancyNutritionController : Controller
    {
        private readonly IUnitOfWork _repo;

        public PregnancyNutritionController(IUnitOfWork repo)
        {
            _repo = repo;
        }

       


        public IActionResult Index()
        {
            IEnumerable<PregnancyBaseNutrition> all = _repo.PregnancyBaseNutrition.GetModel();
            return View(all);
        }

        public IActionResult Details(int id)
        {
            PregnancyBaseNutrition pregnancy = _repo.PregnancyBaseNutrition.GetById(id);
            return View(pregnancy);
        }

        [HttpGet]
        public IActionResult AddEditPregnancy(int? id)
        {
            ViewBag.Species = new SelectList(_repo.Species.GetModel(), "id", "speciesName");
            PregnancyBaseNutrition model = new PregnancyBaseNutrition();
            if (id.HasValue)
            {
                PregnancyBaseNutrition feed = _repo.PregnancyBaseNutrition.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditPregnancy(int? id, PregnancyBaseNutrition model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    //PregnancyBaseNutrition feed = isNew ? new PregnancyBaseNutrition { } : _repo.GetById(id.Value);
                   // feed = model;
                    if (isNew)
                    {
                        _repo.PregnancyBaseNutrition.Insert(model);
                        _repo.Save();
                    }
                    else
                    {
                         //To Avoid tracking error
                       // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repo.PregnancyBaseNutrition.Update(model);
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
        public IActionResult DeletePregnancy(int id)
        {
            PregnancyBaseNutrition feed = _repo.PregnancyBaseNutrition.GetById(id);
            _repo.PregnancyBaseNutrition.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}