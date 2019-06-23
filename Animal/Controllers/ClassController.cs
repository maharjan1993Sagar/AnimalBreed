using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models.ViewModel;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animal.Controllers
{
    public class ClassController : Controller
    {
        private AnimalContext _context;
        public ClassController(AnimalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var lstModel = new List<SimpleReportViewModel>();
            foreach (var item in _context.MilkRecords.Include(m=>m.animalRegistration).ThenInclude(m=>m.Breed).OrderByDescending(m=>m.milkVolume).Take(10))
            
            {
                lstModel.Add(new SimpleReportViewModel
                {
                    
                    DimensionOne = item.animalRegistration.earTagNo.ToString(),
                   
                    Quantity = Convert.ToInt32(item.milkVolume)
                });
            }
        
             return View(lstModel);
          
        }
        public IActionResult Index1()
        {

            var lstModel = new List<SimpleReportViewModel>();
            foreach (var item in _context.MilkRecords.Include(m => m.animalRegistration).ThenInclude(m => m.Breed))

            {
                lstModel.Add(new SimpleReportViewModel
                {

                    DimensionOne = item.animalRegistration.Breed.breedNameShort,

                    Quantity = Convert.ToInt32(item.milkVolume)
                });
            }

            return View(lstModel);

        }
    }
}