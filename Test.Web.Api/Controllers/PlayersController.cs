using Microsoft.AspNetCore.Mvc;
using Test.Data.Tools;
using Test.Entities.Core;
using Test.Entities.DTO;
using Test.Web.Api.Tools;

namespace Test.Web.Api.Controllers
{
    [ServiceFilter(typeof(FilterModelValidation))]
    public class PlayersController : _BaseController<Players>
    {
        public PlayersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        [HttpPost]
        [Route("Add")]
        public  ActionResult<ResultOperation<int>> Add( PlayersDTO _request)
        {
            var tempDAO = _mapperService.SimpleMap<PlayersDTO, Players>(_request);
            var TempRes = WraperHelper.WrapOperation<Players, ActionResult<ResultOperation<int>>>((param) =>
            {
                var ServiceRes = _playersService.Add(param);
                if (ServiceRes == null)
                {
                    return NotFound(ServiceRes);
                }
                else if (!ServiceRes.stateOperation)
                {
                    return BadRequest(ServiceRes);
                }
                else
                {
                    return Ok(ServiceRes);
                }

            }, tempDAO);

            return TempRes.result;
        }

        [HttpPost]
        [Route("AddAsync")]
        public async Task<ActionResult<ResultOperation<int>>> AddAsync(PlayersDTO _request)
        {
            var tempDAO = _mapperService.SimpleMap<PlayersDTO, Players>(_request);
            var TempRes = (await WraperHelper.WrapOperationAsync<Players, ActionResult<ResultOperation<int>>>(async(param) =>
            {
                var ServiceRes = await _playersService.AddAsync(param);
                if (ServiceRes == null)
                {
                    return NotFound(ServiceRes);
                }
                else if (!ServiceRes.stateOperation)
                {
                    return BadRequest(ServiceRes);
                }
                else
                {
                    return Ok(ServiceRes);
                }

            }, tempDAO)).result;

            return TempRes;
        }

    }
}
