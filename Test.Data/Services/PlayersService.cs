using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Repositories.Interfaces;
using Test.Data.Services.Interfaces;
using Test.Data.Tools;
using Test.Entities.Core;
using Test.Entities.DTO;

namespace Test.Data.Services
{
    public class PlayersService : _BaseService<Players>, IPlayersService
    {
        public PlayersService(IPlayersRepository repository) : base(repository)
        {

        }
        public override ResultOperation<int> Add(Players entity)
        {
            return WraperHelper.WrapOperation((param) =>
            {

                return _repository.Add(param)>0?param.Id:0;
            }, entity);
        }
        public async override Task<ResultOperation<int>> AddAsync(Players entity)
        {
            return await WraperHelper.WrapOperationAsync(async (param) =>
            {

                return (await _repository.AddAsync(param)) > 0 ? param.Id : 0;
            }, entity);
        }
    }
}
