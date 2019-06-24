﻿using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
   public interface IEarTagRepository:IRepository<EarTag>
    {
        EarTag GetByTag(string tag);
    }
}
