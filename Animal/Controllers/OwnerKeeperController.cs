using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Models.ViewModel;
using Animal.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal.Controllers
{
    public class OwnerKeeperController : Controller
    {
        private readonly IRepository<OwnerKeeper> _repo;
        private readonly IRepository<Farm> _repoFarm;

        public OwnerKeeperController(IRepository<OwnerKeeper> repo, IRepository<Farm> repofarm)
        {
            _repo = repo;
            _repoFarm = repofarm;
        }


        public IActionResult Index()
        {
            IEnumerable<OwnerKeeper> all = _repo.GetModel();
            return View(all);
        }

        [HttpGet]
        public IActionResult AddEditOwnerKeeper(int? id)
        {
            OwnerKeeper model = new OwnerKeeper();
            OwnerKeeperVM keeperVm = new OwnerKeeperVM();
            keeperVm.farms = new SelectList(_repoFarm.GetModel().ToList(), "id", "orgtanizationName");
            if (id.HasValue)
            {
                OwnerKeeper ownerkeeper = _repo.GetById(id.Value);

                if (ownerkeeper != null)
                {

                    //Mapping the model to viewModel
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<OwnerKeeper, OwnerKeeperVM>();
                    });

                    IMapper mapper = config.CreateMapper();

                    keeperVm = mapper.Map<OwnerKeeper, OwnerKeeperVM>(ownerkeeper);
                    keeperVm.farms = new SelectList(_repoFarm.GetModel().ToList(), "id", "orgtanizationName", ownerkeeper.farmid);


                    keeperVm.id = ownerkeeper.id;
                }
            }
            return View(keeperVm);
        }
        [HttpPost]
        public ActionResult AddEditOwnerKeeper(int? id, OwnerKeeperVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;

                   // OwnerKeeper owner = isNew ? new OwnerKeeper { } : _repo.GetById(id.Value);
                    // feed = model;
                    if (isNew)
                    {
                        //Mapping the model to viewModel
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<OwnerKeeperVM, OwnerKeeper>();
                        });

                        IMapper mapper = config.CreateMapper();

                        OwnerKeeper owner = mapper.Map<OwnerKeeperVM, OwnerKeeper>(model);


                        _repo.Insert(owner);
                        _repo.Save();
                    }
                    else
                    {
                      //  OwnerKeeper owner = _repo.GetById(id.Value);

                        //Mapping the model to viewModel
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<OwnerKeeperVM, OwnerKeeper>();
                        });

                        IMapper mapper = config.CreateMapper();

                        OwnerKeeper owner = mapper.Map<OwnerKeeperVM, OwnerKeeper>(model);
                        

                        //To Avoid tracking error
                        // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repo.Update(owner);
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
        public IActionResult DeleteOwnerKeeper(int id)
        {
            OwnerKeeper feed = _repo.GetById(id);
            _repo.Delete(id);

            return RedirectToAction("Index");

        }
    }
}