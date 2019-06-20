using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
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

        [HttpGet]
        public IActionResult AddEditBreed(int? id)
        {
            Breed model = new Breed();
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
                    bool isNew = !id.HasValue;
                    //FeedFooder feed = isNew ? new FeedFooder { } : _repo.GetById(id.Value);
                    // feed = model;
                    if (isNew)
                    {
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