using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Repositories.Interfaces;
using Test.Data.Services.Interfaces;
using Test.Data.Tools;
using Test.Entities.Core;
using Test.Entities.DTO;

namespace Test.Data.Services
{
    public class DuelsService : _BaseService<Duels>, IDuelsService
    {
        public DuelsService(IDuelsRepository repository) : base(repository)
        {
        }
        public override ResultOperation<int> Add(Duels entity)
        {
            return WraperHelper.WrapOperation((param) =>
            {

                return _repository.Add(param) > 0 ? param.Id : 0;
            }, entity);
        }
        public async override Task<ResultOperation<int>> AddAsync(Duels entity)
        {
            return await WraperHelper.WrapOperationAsync(async (param) =>
            {

                return (await _repository.AddAsync(param)) > 0 ? param.Id : 0;
            }, entity);
        }
        public async Task<bool> UpdateDuelStatusAsync(UpdateDuelDTO ObjDTO)
        {

            var tempDuel = await _repository.GetByKeyAsync(ObjDTO.IdDuel);
            if (tempDuel != null)
            {
                if (ObjDTO.Winner == 1)
                {
                    tempDuel.ScorePlayer1++;
                }
                else
                {
                    tempDuel.ScorePlayer2++;
                }
               return (await _repository.UpdateAsync(tempDuel))>0;
            }
            return false;
        }
    }
}
