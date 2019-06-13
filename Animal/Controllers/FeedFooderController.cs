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
        private readonly IRepository<feedFooder> _repo;

        public FeedFooderController(IRepository<feedFooder> repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            IEnumerable<feedFooder> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditFeed(int? id)
        {
            feedFooder model = new feedFooder();
            if (id.HasValue)
            {
                feedFooder feed = _repo.GetById(id.Value);
                if (feed != null)
                {
                    model = feed;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditFeed(int? id, feedFooder model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    feedFooder feed = isNew ? new feedFooder { } : _repo.GetById(id.Value);
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
            feedFooder feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

       
    }
}