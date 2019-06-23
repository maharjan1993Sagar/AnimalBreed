using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal.Controllers
{
    public class FeedFooderController : Controller
    {
       // private readonly IRepository<FeedFooder> _repo;
        private readonly IUnitOfWork _repoU;

        public FeedFooderController( IUnitOfWork repoU)
        {
         //   _repo = repo;
            _repoU = repoU;
        }


        public IActionResult Index()
    {
            IEnumerable<FeedFooder> all = _repoU.FeedFooder.GetModel();
            //IEnumerable<FeedFooder> all = _repo.GetModel();
            return View(all);
        }

        public IActionResult Details(int id)
        {
            FeedFooder feed = _repoU.FeedFooder.GetById(id);
            return View(feed);
        }

        [HttpGet]
        public IActionResult AddEditFeed(int? id)
        {
            FeedFooder model = new FeedFooder();
            
            if (id.HasValue)
            {
                FeedFooder feed = _repoU.FeedFooder.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditFeed(int? id, FeedFooder model)
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
                        _repoU.FeedFooder.Insert(model);
                        _repoU.FeedFooder.Save();
                    }
                    else
                    {
                         //To Avoid tracking error
                       // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repoU.FeedFooder.Update(model);
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
        public IActionResult DeleteFeed(int id)
        {
            FeedFooder feed = _repoU.FeedFooder.GetById(id);
            _repoU.FeedFooder.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}