using System;
using System.Collections.Generic;
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
    public class PlaysService : _BaseService<Plays>, IPlaysService
    {
        public PlaysService(IPlaysRepository repository) : base(repository)
        {
        }
        public override ResultOperation<int> Add(Plays entity)
        {
            return WraperHelper.WrapOperation((param) =>
            {

                return _repository.Add(param) > 0 ? param.Id : 0;
            }, entity);
        }

        public async override Task<ResultOperation<int>> AddAsync(Plays entity)
        {
            return await WraperHelper.WrapOperationAsync(async(param) =>
            {

                return (await _repository.AddAsync(param)) > 0 ? param.Id : 0;
            }, entity);
        }

        public async Task<ResultOperation<int>> EvalueSelectedOptionsAsync(SelectedOptionsDTO ObjDTO)
        {
            return await WraperHelper.WrapOperationAsync( (param) =>
            {
                return Task.FromResult( (3 + param.OptionValuePlayer1 - param.OptionValuePlayer2) % 3);
            }, ObjDTO);

        }
    }
}
