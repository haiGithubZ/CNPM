using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using System;
using SportSvc.Application.Commands.PromotionC;
using SportSvc.Application.Queries.Promotions;
using SportSvc.Application.Queries.Products;

namespace Jhipster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionController : ControllerBase
    {
        private ILogger<PromotionController> _logger;
        private IMediator _mediator;

        public PromotionController(ILogger<PromotionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        private string GetUserIdFromContext()
        {
            return User.FindFirst("Sub")?.Value;
        }
        [HttpPost("/promotion/create")]
        [Authorize]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionCommand rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create promotion request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                rq.CreatedBy = GetUserIdFromContext();
                rq.LastModifiedBy = GetUserIdFromContext();
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create promotion error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("/promotion/delete")]
        [Authorize]
        public async Task<IActionResult> DeletePromotion([FromBody] DeletePromotionCommand rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Delete promotion request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete promotion error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch("/promotion/update")]
        [Authorize]
        public async Task<IActionResult> UpdatePromotion([FromBody] UpdatePromotionCommand rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update promotion request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                rq.LastModifiedBy = GetUserIdFromContext();
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update promotion error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/promotion/get-all-promotion-product")]
        public async Task<IActionResult> GetAllPromotionOfProduct([FromQuery] GetAllPromotionOfProductQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get all promotion of product request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all promotion of product error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/promotion/get-detail")]
        [Authorize]
        public async Task<IActionResult> GetDetailPromotion([FromQuery] GetDetailPromotionQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get detail promotion request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get detail promotion error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/promotion/get-all-valid-promotion")]
        public async Task<IActionResult> GetAllValidPromotion([FromQuery] GetAllValidPromotionQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get all valid promotion request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all valid promotion  error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
