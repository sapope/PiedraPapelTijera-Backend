using Microsoft.AspNetCore.Mvc;
using Test.Data.Tools;
using Test.Entities.Core;
using Test.Entities.DTO;

namespace Test.Web.Api.Controllers
{
    public class PlaysController : _BaseController<Plays>
    {
        public PlaysController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        [HttpPost]
        [Route("Add")]
        public  ActionResult<ResultOperation<int>> Add([FromBody] PlaysDTO _request)
        {
            var tempDAO = _mapperService.SimpleMap<PlaysDTO, Plays>(_request);
            var tempRes = WraperHelper.WrapOperation<Plays, ActionResult<ResultOperation<int>>>((param) =>
            {
                var ServiceRes = _playsService.Add(param);
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
        public async Task<ActionResult<ResultOperation<int>>> AddAsync([FromBody] PlaysDTO _request)
        {
            var tempDAO = _mapperService.SimpleMap<PlaysDTO, Plays>(_request);
            var tempRes = (await WraperHelper.WrapOperationAsync<Plays, ActionResult<ResultOperation<int>>>(async(param) =>
            {
                var ServiceRes = await _playsService.AddAsync(param);
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

        [HttpPut]
        [Route("GamePlay")]
        public async Task<ActionResult<ResultOperation<int>>> GamePlay([FromBody] GamePlayRequestDTO _request)
        {
            var tempRes = (await WraperHelper.WrapOperationAsync<GamePlayRequestDTO, ActionResult<ResultOperation<int>>>(async(param) =>
            {
                var tempWinner = await _playsService.EvalueSelectedOptionsAsync(new SelectedOptionsDTO() { OptionValuePlayer1 = param.OptionValuePlayer1, OptionValuePlayer2 = param.OptionValuePlayer2 });
                if (tempWinner != null && tempWinner.result > 0)
                {
                    await _duelsService.UpdateDuelStatusAsync(new UpdateDuelDTO() { IdDuel = param.IdDuel, Winner = tempWinner.result });
                }
                if (tempWinner == null)
                {
                    return NotFound(tempWinner);
                }
                else if (!tempWinner.stateOperation)
                {
                    return BadRequest(tempWinner);
                }
                else
                {
                    return Ok(tempWinner);
                }
            }, _request)).result;
            return tempRes;
        }
    }
}
