using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models.ViewModel;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Animal.Models;

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
            fooder1.feeds = new SelectList(_repo.FeedFooder.GetModel(), "id", "feedFooderName");
            fooder1.animalWeight = 0;
            fooder1.category = "";
            fooder1.weight = 0;


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
            string cowWeight = feeds[0].animalWeight.ToString();
            string category = feeds[0].category;
            MIlkBaseNutrition MilkBase = new MIlkBaseNutrition();
            PregnancyBaseNutrition PregancyBase = new PregnancyBaseNutrition();


            FeedFooder fooder = _repo.FeedFooder.GetById(feeds[0].feedId);
            FeedCalculator feed1 = new FeedCalculator();
            feed1.dm = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.dm)).ToString("0.00");
            feed1.c = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.c)).ToString("0.00");
            feed1.p = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.p)).ToString("0.00");
            feed1.tdn = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.tdn)).ToString("0.00");
            feed1.dcp = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.dm)).ToString("0.00");
            feed1.me = (Convert.ToDecimal(feeds[0].weight) * Convert.ToDecimal(fooder.dm)).ToString("0.00");
            feed1.animalWeight = feeds[0].animalWeight;
            feed1.animalCategories = feeds[0].animalCategories;

            feedResult.Add(feed1);

            if (category == "MilkBase")
            {
                MilkBase = _repo.MilkBase.GetByWeight(cowWeight);

                FeedCalculator feed = new FeedCalculator();
                feed.dm = MilkBase.dp;
                feed.tdn = MilkBase.tdn;
                feed.p = MilkBase.p;
                feed.c = MilkBase.c;
                feed.me = MilkBase.dm;
                feed.dcp = MilkBase.dp;
                feed.animalWeight = feeds[0].animalWeight;
                feed.animalCategories = feeds[0].animalCategories;
                feedResult.Add(feed);

            }
            else
            {
                PregancyBase = _repo.PregnancyBaseNutrition.GetByWeight(cowWeight);
                FeedCalculator feed = new FeedCalculator();
                feed.dm = PregancyBase.dp;
                feed.tdn = PregancyBase.tdn;
                feed.p = PregancyBase.p;
                feed.c = PregancyBase.c;
                feed.me = PregancyBase.dp;
                feed.dcp = PregancyBase.dp;
                feed.animalWeight = feeds[0].animalWeight;
                feed.animalCategories = feeds[0].animalCategories;
                feedResult.Add(feed);

            }


            feed1.dm = (Convert.ToDecimal(feedResult[0].dm) - Convert.ToDecimal(feedResult[1].dm)).ToString("0.00");
            feed1.c = (Convert.ToDecimal(feedResult[0].c) - Convert.ToDecimal(feedResult[1].c)).ToString("0.00");
            feed1.p = (Convert.ToDecimal(feedResult[0].p) - Convert.ToDecimal(feedResult[1].p)).ToString("0.00");
            feed1.tdn = (Convert.ToDecimal(feedResult[0].tdn) - Convert.ToDecimal(feedResult[1].tdn)).ToString("0.00");
            feed1.dcp = (Convert.ToDecimal(feedResult[0].dcp) - Convert.ToDecimal(feedResult[1].dcp)).ToString("0.00");
            feed1.me = (Convert.ToDecimal(feedResult[0].me) - Convert.ToDecimal(feedResult[1].me)).ToString("0.00");
            feed1.animalWeight = feeds[0].animalWeight;
            feed1.animalCategories = feeds[0].animalCategories;
            feedResult.Add(feed1);

            return View(feedResult);
        }
    }
}