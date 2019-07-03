using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models.ViewModel
{
    public class AnimalIndexVM
    {
        public SelectList breed { get; set; }
        public SelectList  species { get; set; }
        public SelectList owner { get; set; }
        public SelectList farm { get; set; }
        public IEnumerable<AnimalRegistration> animals { get; set; }
    }
}
