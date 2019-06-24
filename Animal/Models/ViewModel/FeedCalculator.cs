﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Animal.Models.ViewModel
{
    public class FeedCalculator
    {
        public string category { get; set; }
        public decimal animalWeight { get; set; }
        public int feedId { get; set; }
        public decimal weight { get; set; }
        public string remarks { get; set; }
        public string dm { get; set; }
        public string dcp { get; set; }
        public string tdn { get; set; }
        public string me { get; set; }
        public string c { get; set; }
        public string p { get; set; }
        public SelectList feeds { get; set; }
        public SelectList animalCategories { get; set; }
        public SelectList feedCategories { get; set; }
    }
}