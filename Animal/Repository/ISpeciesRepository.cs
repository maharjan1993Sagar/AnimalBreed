using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public interface ISpeciesRepository : IRepository<Species>
    {
        
    }
}
