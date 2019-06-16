﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class MilkBaseNutritionController : Controller
    {
        private readonly IRepository<MIlkBaseNutrition> _repo;

        public MilkBaseNutritionController(IRepository<MIlkBaseNutrition> repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<MIlkBaseNutrition> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditMilk(int? id)
        {
            MIlkBaseNutrition model = new MIlkBaseNutrition();
            if (id.HasValue)
            {
                MIlkBaseNutrition feed = _repo.GetById(id.Value);
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
        public IActionResult DeleteMilk(int id)
        {
            MIlkBaseNutrition feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}