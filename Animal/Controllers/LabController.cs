using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class LabController : Controller
    {
        private readonly IUnitOfWork _repo;

        public LabController(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            IEnumerable<lab> all = _repo.labs.GetModel();
            return View(all);
        }


        public IActionResult Details(int id)
        {
            lab lab = _repo.labs.GetById(id);
            return View(lab);
        }
        [HttpGet]
        public IActionResult AddEditLab(int? id)
        {
            lab model = new lab();
            if (id.HasValue)
            {
                lab lab = _repo.labs.GetById(id.Value);
                if (lab != null)
                {
                    model = lab;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditlab(int? id, lab model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;

                    if (isNew)
                    {
                        _repo.labs.Insert(model);
                        _repo.Save();
                    }
                    else
                    {

                        _repo.labs.Update(model);
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
        public IActionResult Deletelab(int id)
        {
            lab lab = _repo.labs.GetById(id);
            _repo.labs.Delete(id);

            return RedirectToAction("Index");

        }

    }
}