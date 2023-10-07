using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Core;
using Test.Entities.DTO;

namespace Test.Data.Services.Interfaces
{
    public interface IPlaysService :_IBaseService<Plays>
    {
        Task<ResultOperation<int>> EvalueSelectedOptionsAsync(SelectedOptionsDTO ObjDTO);
    }
}
