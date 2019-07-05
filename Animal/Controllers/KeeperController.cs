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
    public class KeeperController : Controller
    {
        private readonly IUnitOfWork _repo;

        public KeeperController(IUnitOfWork repo)
        {
            _repo = repo;
        }



        public IActionResult Index()
        {
            IEnumerable<keeper> all = _repo.keepers.GetModel();
            return View(all);
        }

        public IActionResult Details(int id)
        {
            keeper owner = _repo.keepers.GetById(id);
            return View(owner);
        }


        [HttpGet]
        public ActionResult AddEditKeeper(int? id, keeper model)
        {
            OwnerKeeperVM keeperVm = new OwnerKeeperVM();
            keeperVm.farms = new SelectList(_repo.Farm.GetModel().ToList(), "id", "orgtanizationName");
            if (id.HasValue)
            {
                keeper ownerkeeper = _repo.keepers.GetById(id.Value);

                if (ownerkeeper != null)
                {

                    //Mapping the model to viewModel
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<keeper, OwnerKeeperVM>();
                    });

                    IMapper mapper = config.CreateMapper();

                    keeperVm = mapper.Map<keeper, OwnerKeeperVM>(ownerkeeper);
                    keeperVm.farms = new SelectList(_repo.Farm.GetModel().ToList(), "id", "orgtanizationName", ownerkeeper.farmid);


                    keeperVm.id = ownerkeeper.id;
                }
            }
            return View(keeperVm);
        }
        [HttpPost]
        public ActionResult AddEditKeeper(int? id, OwnerKeeperVM model)

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
                            cfg.CreateMap<OwnerKeeperVM, keeper>();
                        });

                        IMapper mapper = config.CreateMapper();

                        keeper owner = mapper.Map<OwnerKeeperVM, keeper>(model);


                        _repo.keepers.Insert(owner);
                        _repo.Save();
                    }
                    else
                    {
                        var config = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<OwnerKeeperVM, keeper>();
                        });

                        IMapper mapper = config.CreateMapper();

                        keeper owner = mapper.Map<OwnerKeeperVM, keeper>(model);


                        //To Avoid tracking error
                        // DbContextInMemory.Entry(entity).State = EntityState.Detached;
                        _repo.keepers.Update(owner);
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
            keeper feed = _repo.keepers.GetById(id);
            _repo.keepers.Delete(id);

            return RedirectToAction("Index");

        }
    }
}