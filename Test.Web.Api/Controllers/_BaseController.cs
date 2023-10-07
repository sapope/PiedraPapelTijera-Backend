using Microsoft.AspNetCore.Mvc;
using Test.Data.Services.Interfaces;
using Test.Data.Tools;
using Test.Entities.DTO;

namespace Test.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class _BaseController<T> : Controller
        where T : class
    {
        protected readonly IMapperService _mapperService;
        protected readonly _IBaseService<T> _baseService;
        protected readonly IPlayersService _playersService;
        protected readonly IDuelsService _duelsService;
        protected readonly IPlaysService _playsService;

        public _BaseController(IServiceProvider serviceProvider)
        {
            _mapperService = serviceProvider.GetService(typeof(IMapperService)) as IMapperService;
            _baseService = serviceProvider.GetService(typeof(_IBaseService<T>)) as _IBaseService<T>;
            _playersService = serviceProvider.GetService(typeof(IPlayersService)) as IPlayersService;
            _duelsService = serviceProvider.GetService(typeof(IDuelsService)) as IDuelsService;
            _playsService = serviceProvider.GetService(typeof(IPlaysService)) as IPlaysService;
        }

    }
}
