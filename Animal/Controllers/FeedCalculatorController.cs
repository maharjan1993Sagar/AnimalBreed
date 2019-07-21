using Animal.Models;
using Animal.Models.ViewModel;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Animal.Controllers
{
    public class FeedCalulatorController : Controller
    {
        private readonly IUnitOfWork _repo;

        public FeedCalulatorController(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            List<FeedCalculator> fooders = new List<FeedCalculator>();


            FeedCalculator fooder1 = new FeedCalculator();
            fooder1.feeds = new SelectList(_repo.FeedFooder.GetModel(), "id", "fooderNameEng");
            fooder1.animalCategories = new SelectList(_repo.Species.GetModel(), "speciesName", "speciesName");
            fooder1.fatPercentage = 0;
            fooder1.category = "";
            fooder1.weight = 0;
            fooder1.animalWeight = 0;
            
           new List<SelectListItem>{
                                new SelectListItem{ Text="MilkBase", Value = "MilkBase" },
                                new SelectListItem{ Text="PregnancyBase", Value = "PregnancyBase" }
                            };


            fooders.Add(fooder1);

            //FeedCalculator fooder2 = new FeedCalculator();
            //fooder2.feeds = new SelectList(_repo.FeedFooder.GetModel(), "id", "feedFooderName");
            //fooder2.animalWeight = 0;
            //fooder2.category = "";
            //fooder2.weight = 0;


            //fooders.Add(fooder2);
            return View(fooders);
        }
        [HttpPost]
        public IActionResult Calculate(List<FeedCalculator> feeds)
        {
            List<FeedCalculator> feedResult = new List<FeedCalculator>();
            string fat = feeds[0].fatPercentage.ToString();
            string type = feeds[0].type;
            string volumn = feeds[0].milkvolumn;
            string species = feeds[0].species;
            GeneralNutration generalNutrition = new GeneralNutration();
            MIlkBaseNutrition MilkBase = new MIlkBaseNutrition();
            PregnancyBaseNutrition PregancyBase = new PregnancyBaseNutrition();

            if (_repo.FeedFooder.GetById(feeds[0].feedId) == null ||
                _repo.GeneralNutrition.GetByWeight(feeds[0].animalWeight.ToString(),species)==null
                )
            {
                ModelState.AddModelError(string.Empty, "Feed Fooder Record Not Found.");
                feeds[0].feeds = new SelectList(_repo.FeedFooder.GetModel(), "id", "fooderNameEng",feeds[0].feedId);
                feeds[0].animalCategories = new SelectList(_repo.Species.GetModel(), "speciesName", "speciesName",feeds[0].category);
                return View(feeds);
            }
           
            FeedFooder fooder = _repo.FeedFooder.GetById(feeds[0].feedId);
            FeedCalculator feed1 = new FeedCalculator();
            feed1.dm = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.dm)*Convert.ToDecimal(0.01)).ToString("0.00");
            feed1.c = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.c) * Convert.ToDecimal(0.01)).ToString("0.00");
            feed1.p = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.p) * Convert.ToDecimal(0.01)).ToString("0.00");
            feed1.tdn = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.tdn) * Convert.ToDecimal(0.01)).ToString("0.00");
            feed1.dcp = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.dm) * Convert.ToDecimal(0.01)).ToString("0.00");
            feed1.me = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.dm) * Convert.ToDecimal(0.01)).ToString("0.00");
            feed1.fatPercentage = feeds[0].fatPercentage;
            feed1.animalWeight = feeds[0].animalWeight;
            feed1.animalCategories = feeds[0].animalCategories;
            feed1.remarks = "Feed Fooder";

            feedResult.Add(feed1);

            if (type == "MilkBase")
            {
                generalNutrition = _repo.GeneralNutrition.GetByWeight(feeds[0].animalWeight.ToString(),species);
                
                MilkBase = _repo.MilkBase.GetByFat(fat,int.Parse(species));
                if (MilkBase == null)
                {
                    ModelState.AddModelError(string.Empty, "Milk Base Record Not Found.");
                    feeds[0].feeds = new SelectList(_repo.FeedFooder.GetModel(), "id", "fooderNameEng", feeds[0].feedId);
                    feeds[0].animalCategories = new SelectList(_repo.Species.GetModel(), "speciesName", "speciesName", feeds[0].category);
                    return View(feeds);
                }
                FeedCalculator feed = new FeedCalculator();
                feed.dm = (Convert.ToDecimal(generalNutrition.dm)+Convert.ToDecimal(MilkBase.dm)).ToString();
                feed.tdn = (Convert.ToDecimal(generalNutrition.tdn) + Convert.ToDecimal(MilkBase.tdn)).ToString();
                feed.p = (Convert.ToDecimal(generalNutrition.p) + Convert.ToDecimal(MilkBase.p)).ToString();
                feed.c = (Convert.ToDecimal(generalNutrition.c) + Convert.ToDecimal(MilkBase.c)).ToString();
                // feed.me = generalNutrition.me;
                //feed.dcp = generalNutrition.dp;
                feed.fatPercentage = feeds[0].fatPercentage;
                feed.category = feeds[0].category;
                feed.animalWeight = feeds[0].animalWeight;
                feed.remarks = "Required";
                feedResult.Add(feed);
                

            }
            else
            {

                generalNutrition = _repo.GeneralNutrition.GetByWeight(feeds[0].animalWeight.ToString(),species);

                PregancyBase = _repo.PregnancyBaseNutrition.GetBySpecies(feeds[0].animalWeight.ToString());
                if (PregancyBase == null)
                {
                    ModelState.AddModelError(string.Empty, "Preganancy Base Record Not Found.");
                    feeds[0].feeds = new SelectList(_repo.FeedFooder.GetModel(), "id", "fooderNameEng", feeds[0].feedId);
                    feeds[0].animalCategories = new SelectList(_repo.Species.GetModel(), "speciesName", "speciesName", feeds[0].category);
                    return View(feeds);
                }

                FeedCalculator feed = new FeedCalculator();
                feed.dm = (Convert.ToDecimal(generalNutrition.dm) + Convert.ToDecimal(PregancyBase.dm)).ToString();
                feed.tdn = (Convert.ToDecimal(generalNutrition.tdn) + Convert.ToDecimal(PregancyBase.tdn)).ToString();
                feed.p = (Convert.ToDecimal(generalNutrition.p) + Convert.ToDecimal(PregancyBase.p)).ToString();
                feed.c = (Convert.ToDecimal(generalNutrition.c) + Convert.ToDecimal(PregancyBase.c)).ToString();
              
                feed.fatPercentage = feeds[0].fatPercentage;
                feed.animalCategories = feeds[0].animalCategories;
                feed.remarks = "Required";
                feedResult.Add(feed);

            }

            FeedCalculator feed2 = new FeedCalculator();
            feed2.dm = (Convert.ToDecimal(feedResult[0].dm) - Convert.ToDecimal(feedResult[1].dm)).ToString("0.00");
            feed2.c = (Convert.ToDecimal(feedResult[0].c) - Convert.ToDecimal(feedResult[1].c)).ToString("0.00");
            feed2.p = (Convert.ToDecimal(feedResult[0].p) - Convert.ToDecimal(feedResult[1].p)).ToString("0.00");
            feed2.tdn = (Convert.ToDecimal(feedResult[0].tdn) - Convert.ToDecimal(feedResult[1].tdn)).ToString("0.00");
           feed2.fatPercentage = feeds[0].fatPercentage;
            feed2.category = feeds[0].category;
            feed2.remarks = "Result";
            feedResult.Add(feed2);

            return View(feedResult);
        }





    }
}