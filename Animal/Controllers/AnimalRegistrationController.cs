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
            //IEnumerable<AnimalRegistration> all = _repo.AnimalRegistration.GetModel();
            return View(model.animals);
        }

        [HttpGet]
        public IActionResult AddEditAnimal(int? id)
        {
            //AnimalRegistration model = new AnimalRegistration();
            AnimalVM model = new AnimalVM();
            model.farms = new SelectList(_repo.Farm.GetModel(), "id", "orgtanizationName");
            model.owners = new SelectList(_repo.Farm.GetModel(), "id", "fullName");
            if (id.HasValue)
            {
                AnimalRegistration feed = _repo.AnimalRegistration.GetById(id.Value);
                if (feed != null)
                {

                    //Mapping model and viewModel

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<AnimalRegistration, AnimalVM>();

                    });

                    IMapper iMapper = config.CreateMapper();
                    model = iMapper.Map<AnimalRegistration, AnimalVM>(feed);
                    if (model.farmId.HasValue && model.farmId.ToString() != "0")
                    {
                        model.farms = new SelectList(_repo.Farm.GetModel(), "id", "orgtanizationName", model.farmId.Value);
                    }
                    if (model.ownerId.HasValue && model.ownerId.ToString() != "0")
                    {
                        model.owners = new SelectList(_repo.Farm.GetModel(), "id", "fullName", model.ownerId.Value);
                    }
                }
            }
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