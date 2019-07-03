using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Animal.Models;
using Animal.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Animal.Controllers
{
   // [Authorize]
    public class MilkRecordController : Controller
    {
        private readonly IUnitOfWork _repo;
        public MilkRecordController(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            IEnumerable<MilkRecord> all = _repo.MilkRecord.GetModel();
            return View(all);
        }

        public IActionResult Details(int id)
        {
            MilkRecord milk = _repo.MilkRecord.GetById(id);
                return View(milk);
        }

        [HttpGet]
        public IActionResult AddEditMilk(int? id)
        {
            MilkRecordVM model = new MilkRecordVM();
        
            if (id.HasValue)
            {
                MilkRecord feed = _repo.MilkRecord.GetById(id.Value);
               // model.animals = new SelectList(_repo.AnimalRegistration.GetModel(), "id", "earTagNo");
                if (feed != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MilkRecord,MilkRecordVM>();

                    });

                    IMapper iMapper = config.CreateMapper();
                    model = iMapper.Map<MilkRecord, MilkRecordVM>(feed);
                  
                }
            }
            model.animals = new SelectList(_repo.AnimalRegistration.GetByGender("Female"), "id", "earTagNo");
            model.labs = new SelectList(_repo.labs.GetModel(), "id", "name");
            model.recordingDate = DateTime.Now.Date;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEditMilk(int? id, MilkRecordVM model)
        {
            try
            {
                model.animals = new SelectList(_repo.AnimalRegistration.GetModel(), "id", "earTagNo",model.animalRegistrationid);
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    //FeedFooder feed = isNew ? new FeedFooder { } : _repo.GetById(id.Value);
                    // feed = model;
                    if (isNew)
                    {
                        model.earTagNumber = _repo.AnimalRegistration.GetById(model.animalRegistrationid.Value).earTagNo;
                        model.animalRegistrationid = Convert.ToInt32(model.animalRegistrationid.Value);
                        model.animalRegistration = _repo.AnimalRegistration.GetById(model.animalRegistrationid.Value);
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<MilkRecordVM, MilkRecord>();
                        });

                        IMapper iMapper = config.CreateMapper();
                        MilkRecord milk = iMapper.Map<MilkRecordVM, MilkRecord>(model);
                        _repo.MilkRecord.Insert(milk);
                        _repo.Save();
                    }
                    else
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<MilkRecordVM, MilkRecord>();
                        });

                        IMapper iMapper = config.CreateMapper();

                        MilkRecord milk = iMapper.Map<MilkRecordVM, MilkRecord>(model);
                        milk.animalRegistration = _repo.AnimalRegistration.GetById(model.animalRegistrationid.Value);
                        //To Avoid tracking error
                        // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        milk.earTagNumber = milk.animalRegistration.earTagNo;
                        _repo.MilkRecord.Update(milk);
                    }
                }
                else {
                    model.animals = new SelectList(_repo.AnimalRegistration.GetByGender("Female"), "id", "earTagNo",model.animalRegistrationid);
                    model.labs = new SelectList(_repo.labs.GetModel(), "id", "name",model.labId);

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
        public IActionResult DeleteMilk(int id)
        {
            MilkRecord feed = _repo.MilkRecord.GetById(id);
            _repo.MilkRecord.Delete(id);

            return RedirectToAction("Index");

        }


    }
}