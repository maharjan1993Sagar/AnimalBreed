﻿using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class FarmRepository:Repository<Farm>, IFarmRepository
    {
        public FarmRepository(AnimalContext Context):base(Context)
        {

        }

    }
}
