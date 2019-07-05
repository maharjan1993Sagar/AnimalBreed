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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Animal.Controllers
{
    public class AnimalRegistrationController : Controller
    {
        private readonly IUnitOfWork _repo;
        private readonly IHostingEnvironment _host;

        

        public AnimalRegistrationController(IUnitOfWork repo,IHostingEnvironment host)
        {
            _host = host;
            _repo = repo;
        }
        public IActionResult Index()
        {
            AnimalIndexVM indexvm = new AnimalIndexVM();
           
            indexvm.animals= _repo.AnimalRegistration.GetModel();
            indexvm.species = new SelectList(_repo.Species.GetModel(), "speciesName", "speciesName");
            indexvm.owner = new SelectList(_repo.OwnerKeeper.GetModel(), "fullName", "fullName");
            indexvm.farm = new SelectList(_repo.Farm.GetModel(), "orgtanizationName", "orgtanizationName");
            indexvm.breed = new SelectList(_repo.Breed.GetModel(), "breedNameShort", "breedNameShort");
            return View(indexvm);
        }

        public IActionResult Details(int id)
        {
            AnimalRegistration feed = _repo.AnimalRegistration.GetById(id);
            if (feed != null)
            {
                ViewBag.Image = Path.Combine(_host.WebRootPath, "\\images\\animal\\" + feed.earTagNo + ".jpg");
                ViewBag.defaultimg = Path.Combine(_host.WebRootPath, "\\images\\cow.png");
            }
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
            model.owners = new SelectList(_repo.OwnerKeeper.GetModel(), "id", "fullName");
            model.farms = new SelectList(_repo.Farm.GetModel(), "id", "orgtanizationName");
            model.keepers = new SelectList(_repo.keepers.GetModel(), "id", "fullName");
            model.dams = new SelectList(_repo.AnimalRegistration.GetModel().Where(m=>m.gender=="Male"), "id", "earTagNo");
            model.sires = new SelectList(_repo.AnimalRegistration.GetModel().Where(m => m.gender == "Female"), "id", "earTagNo");
            model.id = 0;


            model.declaredDate = DateTime.Now.Date;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditAnimal(int? id, AnimalVM model, IFormFile file)
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
                            cfg.CreateMap<AnimalVM, AnimalRegistration>();
                        });

                        IMapper iMapper = config.CreateMapper();
                        AnimalRegistration animal = iMapper.Map<AnimalVM, AnimalRegistration>(model);
                        animal.createdAt = DateTime.Now.ToShortDateString();
                        animal.EarTag = _repo.EarTag.GetByTag(model.earTagNo);
                        animal.earTagId = animal.EarTag.id;
                        _repo.AnimalRegistration.Insert(animal);
                        _repo.Save();
                        var path = _host.WebRootPath + "\\images\\animal\\";

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        if (file != null)
                        {

                            var fileName = Path.Combine(path, animal.earTagNo + ".jpg");
                            file.CopyTo(new FileStream(fileName, FileMode.Create));
                        }
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
                else
                {
                    model.speciess = new SelectList(_repo.Species.GetModel(), "id", "speciesName",model.speciesId);
                    model.breeds = new SelectList(_repo.Breed.GetModel(), "id", "breedNameShort",model.breedId);
                    model.owners = new SelectList(_repo.OwnerKeeper.GetModel(), "id", "fullName",model.ownerId);
                    model.keepers = new SelectList(_repo.keepers.GetModel(), "id", "fullName",model.keeperId);
                    model.farms = new SelectList(_repo.Farm.GetModel(), "id", "orgtanizationName",model.farmId);
                    model.dams = new SelectList(_repo.AnimalRegistration.GetModel().Where(m => m.gender == "Male"), "id", "earTagNo",model.damId);
                    model.sires = new SelectList(_repo.AnimalRegistration.GetModel().Where(m => m.gender == "Female"), "id", "earTagNo",model.sireId);
                    model.declaredDate = DateTime.Now.Date;
                    return View(model);
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