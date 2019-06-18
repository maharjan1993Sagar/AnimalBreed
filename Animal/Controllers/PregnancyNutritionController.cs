using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class PregnancyNutritionController : Controller
    {
        private readonly IRepository<PregnancyBaseNutrition> _repo;

        public PregnancyNutritionController(IRepository<PregnancyBaseNutrition> repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<PregnancyBaseNutrition> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditPregnancy(int? id)
        {
            PregnancyBaseNutrition model = new PregnancyBaseNutrition();
            if (id.HasValue)
            {
                PregnancyBaseNutrition feed = _repo.GetById(id.Value);
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
                        _repo.Insert(model);
                        _repo.Save();
                    }
                    else
                    {
                         //To Avoid tracking error
                       // DbContextInMemory.Entry(entity).State = EntityState.Detached;
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
        public IActionResult DeletePregnancy(int id)
        {
            PregnancyBaseNutrition feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}