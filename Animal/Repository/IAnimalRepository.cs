using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
   public interface IAnimalRepository : IRepository<AnimalRegistration>
    {
        IEnumerable<AnimalRegistration> GetModel();
        IEnumerable<AnimalRegistration> GetByGender(string gender);
        AnimalRegistration GetByEartag(string eartag);
    }
}
