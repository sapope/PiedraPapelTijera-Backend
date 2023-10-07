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
    public class PlayersRepository : _BaseRepository<Players>, IPlayersRepository
    {
        public PlayersRepository(DbContextTest context) : base(context)
        {

        }

    }
}
