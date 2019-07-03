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
    public class BreedController : Controller
    {
        private readonly IUnitOfWork _repo;

        public BreedController(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            IEnumerable<Breed> all = _repo.Breed.GetModel();
            return View(all);
        }

        public IActionResult Details(int id)
        {
            Breed feed = _repo.Breed.GetById(id);
            return View(feed);

        }

        [HttpGet]
        public IActionResult AddEditBreed(int? id)
        {
            Breed model = new Breed();
            
       
            ViewBag.Species = new SelectList(_repo.Species.GetModel(), "id", "speciesName");
            if (id.HasValue)
            {
                
                Breed feed = _repo.Breed.GetById(id.Value);
               
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditBreed(int? id, Breed model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = false;
                    //FeedFooder feed = isNew ? new FeedFooder { } : _repo.GetById(id.Value);
                    // feed = model;
                    if(!id.HasValue)
                    {
                        model.updatedBy = "admin";
                        isNew =true;
                    }
                    if (isNew)
                    {
                        
                        model.id = 0;
                        model.registeredBy = "admin";
                        model.registeredDate = DateTime.Now;
                        _repo.Breed.Insert(model);
                        _repo.Save();
                    }
                    else
                    {
                        //To Avoid tracking error
                        // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repo.Breed.Update(model);
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
        public IActionResult DeleteBreed(int id)
        {
            Breed feed = _repo.Breed.GetById(id);
            _repo.Breed.Delete(id);

            return RedirectToAction("Index");

        }
    }
}