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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;
        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        private string GetUserIdFromContext()
        {
            return User.FindFirst("Sub")?.Value;
        }
        [HttpPost("/product/create")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create product request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                rq.CreatedBy = GetUserIdFromContext();
                rq.LastModifiedBy = GetUserIdFromContext();
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create product error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("/product/delete")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Delete product request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete product error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch("/product/update")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update product request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                rq.LastModifiedBy = GetUserIdFromContext();
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update product error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/product/get-detail")]
        public async Task<IActionResult> GetDetailProduct([FromQuery]GetDetailProductQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get detail product request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get detail product error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/product/get-all-product-sportId")]
        public async Task<IActionResult> GetAllProductBySportId([FromQuery] GetAllProductBySportIdQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Get all product by sportId request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all product by sportId error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/product/search-product")]
        public async Task<IActionResult> SearchProduct([FromQuery]  SearchProductQuery rq, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Search product request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Search product error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/get-all-product-in-shop")]
        [Authorize]
        public async Task<IActionResult> GetAllPRoductInShop([FromQuery] GetAllProductInShopQuery rq)
        {
            _logger.LogInformation($"Get All product In Shop request :{JsonConvert.SerializeObject("rq")}");
            try
            {
                var value = await _mediator.Send(rq);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get All product In Shop error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
