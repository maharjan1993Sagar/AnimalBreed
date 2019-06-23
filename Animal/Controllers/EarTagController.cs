using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Animal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    public class EarTagController : Controller
    {
        private readonly IUnitOfWork _repo;

        public EarTagController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GenerateEarTag()
        {
            return View();
        }
        public IActionResult GenerateEarTag(int start, int End)
        {
            long startNum = start;
            long endNum = End;
            
            List<EarTag> EarTags = new List<EarTag>();
            string startStr = start.ToString().PadLeft(12, '0');
            string endStr = End.ToString().PadLeft(12, '0');
            //Loop from start Num to End Num
            for (int i = start; i <= End; i++)
            {
                //Reverse the Num
                char[] Num = i.ToString().ToCharArray();
                Array.Reverse(Num);
                int sum = 0;
                int j = 1;
                int checkBit = 0;

                //Calculation of checkout
                foreach (var item in Num)
                {
                    sum = sum + Convert.ToInt32(item) * j;
                    j++;
                }
                checkBit = sum % 7;
                Array.Reverse(Num);

                //Append Checkbit
                Num.ToString().Append(Convert.ToChar(checkBit));
                Num.ToString().PadLeft(12, '0');


                string newNum = new string(Num);
                //Add Items to List
                EarTag ear = new EarTag();
                ear.earTagNo = Convert.ToInt32(newNum);
                ear.earTagNoStr = Num.ToString();


                _repo.EarTag.Insert(ear);

            }



            return View();
        }

    }
}