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
    //[Authorize]
    public class MilkBaseNutritionController : Controller
    {
        private readonly IUnitOfWork _repo;

        public MilkBaseNutritionController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<MIlkBaseNutrition> all = _repo.MilkBase.GetModel();
            return View(all);
        }

        public IActionResult Details(int id)
        {
            MIlkBaseNutrition milk = _repo.MilkBase.GetById(id);
            return View(milk);
        }

        [HttpGet]
        public IActionResult AddEditMilk(int? id)
        {
            MIlkBaseNutrition model = new MIlkBaseNutrition();
            ViewBag.Species = new SelectList(_repo.Species.GetModel(), "id", "speciesName");
            if (id.HasValue)
            {
                MIlkBaseNutrition feed = _repo.MilkBase.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditMilk(int? id, MIlkBaseNutrition model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    //MIlkBaseNutrition feed = isNew ? new MIlkBaseNutrition { } : _repo.GetById(id.Value);
                   // feed = model;
                    if (isNew)
                    {
                        _repo.MilkBase.Insert(model);
                        _repo.Save();
                    }
                    else
                    {
                         //To Avoid tracking error
                       // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repo.MilkBase.Update(model);
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
        public IActionResult DeleteMilk(int id)
        {
            MIlkBaseNutrition feed = _repo.MilkBase.GetById(id);
            _repo.MilkBase.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}