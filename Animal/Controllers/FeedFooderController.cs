using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class FeedFooderController : Controller
    {
        private readonly IRepository<FeedFooder> _repo;

        public FeedFooderController(IRepository<FeedFooder> repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<FeedFooder> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditFeed(int? id)
        {
            FeedFooder model = new FeedFooder();
            if (id.HasValue)
            {
                FeedFooder feed = _repo.GetById(id.Value);
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
                    FeedFooder feed = isNew ? new FeedFooder { } : _repo.GetById(id.Value);
                    feed = model;
                    if (isNew)
                    {
                        _repo.Insert(feed);
                        _repo.Save();
                    }
                    else
                    {
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
        public IActionResult DeleteFeed(int id)
        {
            FeedFooder feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}