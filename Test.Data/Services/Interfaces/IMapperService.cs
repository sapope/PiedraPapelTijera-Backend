using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Services.Interfaces
{
    public interface IMapperService
    {
        TDestination SimpleMap<TSource, TDestination>(TSource source);
    }
}
