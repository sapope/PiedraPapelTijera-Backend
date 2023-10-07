using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Context;
using Test.Data.Repositories.Interfaces;
using Test.Entities.Core;

namespace Test.Data.Repositories
{
    public class DuelsRepository : _BaseRepository<Duels>, IDuelsRepository
    {
        public DuelsRepository(DbContextTest context) : base(context)
        {

        }
    }
}
