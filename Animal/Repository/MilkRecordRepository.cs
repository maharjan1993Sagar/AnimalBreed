using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
namespace Animal.Repository
{
    public class MilkRecordRepository:Repository<MilkRecord>,IMilkRecordRepository
    {
        public MilkRecordRepository(AnimalContext Context)
                   : base(Context)
        {
        }

        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }
    }
}
