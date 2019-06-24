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
            IEnumerable<EarTag> all = _repo.EarTag.GetModel();
            return View(all);
        }
        [HttpGet]
        public IActionResult GenerateEarTag()
        {
            EarTag ear = _repo.EarTag.GetModel().LastOrDefault();
            if (ear != null)
            {
                if (ear.earTagNo != 0)
                {
                    ViewBag.LastNum = (ear.earTagNo / 10).ToString();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult GenerateEarTag(int start, int End)
        {
            if (start > End)
            {
                ModelState.AddModelError(string.Empty, "Start Number must be Less than End Number.");
                return View();
            }
            List<EarTag> listEar = new List<EarTag>();
            long startNum = start;
            long endNum = End;
            
            List<EarTag> EarTags = new List<EarTag>();
            string startStr = start.ToString().PadLeft(12, '0');
            string endStr = End.ToString().PadLeft(12, '0');
            //Loop from start Num to End Num
            for (int i = start; i <= End; i++)
            {
                //Reverse the Num
                int Num = i;
                //string Reverse = "0";
                string numString = i.ToString();
                char[] charArray = numString.ToCharArray();
                Array.Reverse(charArray);
                string revString = new string(charArray);
                // If you need the numeric value too:
                int revNumber = Convert.ToInt32(revString);
                int sum = 0;
                int j = 1;
                int checkBit = 0;

                //Calculation of checkout
                foreach (char item in revString)
                {
                    sum = sum + Convert.ToInt32(item.ToString()) * j;
                    j++;
                }
                checkBit = sum % 7;
                //Append Checkbit

                string newNum = Num.ToString().Insert(Num.ToString().Length, checkBit.ToString());




                // Num.ToString().PadLeft(12, '0');

                //Add Items to List
                EarTag ear = new EarTag();
                ear.earTagNo = Convert.ToInt32(newNum);
                ear.earTagNoStr = ear.earTagNo.ToString();

                listEar.Add(ear);

                //_repo.EarTag.Insert(ear);

                // //Reverse the Num
                // int Num = i;
                // int Reverse = 0;
                // int k = i;
                // while (k > 0)
                // {
                //     int remainder = k % 10;
                //     Reverse = (Reverse * 10) + remainder;
                //     k = k / 10;
                // }
                // int sum = 0;
                // int j = 1;
                // int checkBit = 0;

                // //Calculation of checkout
                // foreach (char item in Reverse.ToString())
                // {
                //     sum = sum + Convert.ToInt32(item.ToString()) * j;
                //     j++;
                // }
                // checkBit = sum % 7;
                // //Append Checkbit

                // string newNum = Num.ToString().Insert(Num.ToString().Length,checkBit.ToString());




                //// Num.ToString().PadLeft(12, '0');

                // //Add Items to List
                // EarTag ear = new EarTag();
                // ear.earTagNo = Convert.ToInt32(newNum);
                // ear.earTagNoStr = ear.earTagNo.ToString();

                // listEar.Add(ear);

                // //_repo.EarTag.Insert(ear);

            }

            string EarTagsExists = "";
            for (int i = 0; i < listEar.Count; i++)
            {
                EarTag ear = _repo.EarTag.GetByTag(listEar[i].earTagNoStr);
                if (ear == null)
                {
                    _repo.EarTag.Insert(listEar[i]);
                }
                else
                {
                    EarTagsExists = listEar[i].earTagNoStr + ",";
                }
               

            }
            if (EarTagsExists != "")
            {
                ModelState.AddModelError(string.Empty, EarTagsExists+" already exists. Remaining exists.");
            }

            return RedirectToAction("Index");
        }

    }
}