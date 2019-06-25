using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;
using Animal.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using System.Dynamic;

namespace Animal.Controllers
{
    public class AnimalRegistrationController : Controller
    {
        private readonly IUnitOfWork _repo;

        public AnimalRegistrationController(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.animals= _repo.AnimalRegistration.GetModel();
            
            return View(model.animals);
        }

        public IActionResult Details(int id)
        {
            AnimalRegistration feed = _repo.AnimalRegistration.GetById(id);
            return View(feed);
        }

        [HttpGet]
        public IActionResult AddEditAnimal(int? id)
        {
           
            AnimalVM model = new AnimalVM();
         
            if (id.HasValue)
            {
                AnimalRegistration feed = _repo.AnimalRegistration.GetById(id.Value);

                
                if (feed != null)
                {

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<AnimalRegistration, AnimalVM>();

                    });
    
                    IMapper iMapper = config.CreateMapper();
                    model = iMapper.Map<AnimalRegistration, AnimalVM>(feed);
         
                }
            }
            model.speciess = new SelectList(_repo.Species.GetModel(), "id", "speciesName");
            model.breeds = new SelectList(_repo.Breed.GetModel(), "id", "breedNameShort");
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditAnimal(int? id, AnimalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                       
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<AnimalVM,AnimalRegistration>();
                        });

                        IMapper iMapper = config.CreateMapper();
                        AnimalRegistration animal = iMapper.Map<AnimalVM, AnimalRegistration>(model);
                        animal.createdAt = DateTime.Now.ToShortDateString();
                        animal.EarTag = _repo.EarTag.GetByTag(model.earTagNo);
                        animal.earTagId = animal.EarTag.id;
                        _repo.AnimalRegistration.Insert(animal);
                        _repo.Save();
                    }
                    else
                    {

                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<AnimalVM, AnimalRegistration>();
                        });

                        IMapper iMapper = config.CreateMapper();

                        AnimalRegistration animal = iMapper.Map<AnimalVM, AnimalRegistration>(model);
                        animal.EarTag = _repo.EarTag.GetByTag(model.earTagNo);
                        animal.earTagId = animal.EarTag.id;
                        animal.updatedBy = "admin";

                        _repo.AnimalRegistration.Update(animal);
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
        public IActionResult DeleteAnimal(int id)
        {
            AnimalRegistration feed = _repo.AnimalRegistration.GetById(id);
            _repo.AnimalRegistration.Delete(id);

            return RedirectToAction("Index");

        }
    }
}