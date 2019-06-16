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
        private readonly IRepository<Farm> _repo;
        private readonly IFarmRepository _repoFarm;

        public FarmController(IRepository<Farm> repo, IFarmRepository repoFarm)
        {
            _repo = repo;
          _repoFarm = repoFarm;
        }


        public IActionResult Index()
        {
            IEnumerable<Farm> all = _repo.GetModel();
            return View(all);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Farm all =/* _repo.FindByCondition(x => x.OwnerKeepers.SelectMany());*/_repoFarm.GetById(id.Value);
            return View(all);
        }
        [HttpGet]
        public IActionResult AddEditFarm(int? id)
        {
            Farm model = new Farm();
            if (id.HasValue)
            {
                Farm feed = _repo.GetById(id.Value);
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
                    //FeedFooder feed = isNew ? new FeedFooder { } : _repo.GetById(id.Value);
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
        public IActionResult DeleteFarm(int id)
        {
            Farm feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }

    }
}