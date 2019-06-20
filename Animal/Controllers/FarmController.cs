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
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Farm all = _repoFarm.GetById(id.Value);
            return View(all);
        }
        [HttpGet]
        public IActionResult AddEditFarm(int? id)
        {
            Farm model = new Farm();
            if (id.HasValue)
            {
                Farm feed = _repo.GetById(id.Value);
=======
            IEnumerable<Farm> all = _repo.Farm.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditFarm(int? id)
        {
           Farm model = new Farm();
            if (id.HasValue)
            {
                Farm feed = _repo.Farm.GetById(id.Value);
>>>>>>> eab69796949eb7bb537bd59de1ba6f1246a33b7b
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
<<<<<<< HEAD
                    //FeedFooder feed = isNew ? new FeedFooder { } : _repo.GetById(id.Value);
                    // feed = model;
                    if (isNew)
                    {
                        _repo.Insert(model);
=======
                   
                    if (isNew)
                    {
                        _repo.Farm.Insert(model);
>>>>>>> eab69796949eb7bb537bd59de1ba6f1246a33b7b
                        _repo.Save();
                    }
                    else
                    {
<<<<<<< HEAD
                        //To Avoid tracking error
                        // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repo.Update(model);
=======
                        
                        _repo.Farm.Update(model);
>>>>>>> eab69796949eb7bb537bd59de1ba6f1246a33b7b
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
<<<<<<< HEAD
            Farm feed = _repo.GetById(id);
            _repo.Delete(id);
=======
            Farm feed = _repo.Farm.GetById(id);
            _repo.Farm.Delete(id);
>>>>>>> eab69796949eb7bb537bd59de1ba6f1246a33b7b

            return RedirectToAction("Index");

        }

    }
}