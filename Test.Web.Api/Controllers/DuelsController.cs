using Microsoft.AspNetCore.Mvc;
using Test.Data.Tools;
using Test.Entities.Core;
using Test.Entities.DTO;

namespace Test.Web.Api.Controllers
{
    public class DuelsController : _BaseController<Duels>
    {
        public DuelsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult<ResultOperation<int>> Add([FromBody] DuelsDTO _request)
        {
            var tempDAO = _mapperService.SimpleMap<DuelsDTO, Duels>(_request);
            var tempRes = WraperHelper.WrapOperation<Duels, ActionResult<ResultOperation<int>>>((param) =>
            {
                var ServiceRes = _duelsService.Add(param);
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

            }, tempDAO).result;

            return tempRes;
        }

        [HttpPost]
        [Route("AddAsync")]
        public async Task<ActionResult<ResultOperation<int>>> AddAsync([FromBody] DuelsDTO _request)
        {
            var tempDAO = _mapperService.SimpleMap<DuelsDTO, Duels>(_request);
            var tempRes =(await WraperHelper.WrapOperationAsync<Duels, ActionResult<ResultOperation<int>>>(async(param) =>
            {
                var ServiceRes = await _duelsService.AddAsync(param);
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

            return tempRes;
        }
    }
}
