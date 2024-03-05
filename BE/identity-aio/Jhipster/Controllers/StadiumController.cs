using Jhipster.Crosscutting.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using SportSvc.Application.Commands.ProductsC;
using SportSvc.Application.Queries.Products;

namespace Jhipster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StadiumController : ControllerBase
    {
        private readonly ILogger<StadiumController> _logger;
        private readonly IMediator _mediator;
        public StadiumController(ILogger<StadiumController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        private string GetUserIdFromContext()
        {
            return User.FindFirst("Sub")?.Value;
        }


        [HttpGet("/stadium/get-detail")]
        public async Task<IActionResult> GetDetailStadium([FromQuery] GetDetailStadiumQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get detail stadium request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get detail stadium error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/stadium/get-all-stadium")]
        public async Task<IActionResult> GetAllStadium([FromQuery] GetAllStadiumQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get all stadium request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all stadium error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/stadium/search-stadium")]
        public async Task<IActionResult> SearchStadium([FromQuery] SearchStadiumQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Search stadium request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Search stadium error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
