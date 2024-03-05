using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportSvc.Application.Commands.ShoppingCartss;
using SportSvc.Application.Queries.ShoppingCartQ;
using System;
using System.Threading.Tasks;

namespace Jhipster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportSvcController : ControllerBase
    {
        private ILogger<SportSvcController> _logger;
        private IMediator _mediator;

        public SportSvcController(ILogger<SportSvcController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        private string GetUserIdFromContext()
        {
            return User.FindFirst("Sid")?.Value;
        }
        private string GetUsernameFromContext()
        {
            return User.FindFirst("Sub")?.Value;
        }
        #region Address
        [HttpPost("/address/create")]
        [Authorize]
        public async Task<IActionResult> AddAddressByUser([FromBody] AddAddressByUserCommand rq)
        {
            _logger.LogInformation($"Add Address by User request is: {rq}");
            try
            {
                rq.CreatedDate = DateTime.Now;
                rq.CreatedBy = GetUsernameFromContext();
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Add Address by User request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/address/delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAddressByUser([FromBody] DeleteAddressByUserCommand rq)
        {
            _logger.LogInformation($"Delete Address by User request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Delete Address by User request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/address/view-all-by-UserId")]
        [Authorize]
        public async Task<IActionResult> ViewAllAddressByUser([FromQuery] ViewAllAddressByUserQuery rq)
        {
            _logger.LogInformation($"View all Address by User request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"View all Address by User request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/address/update")]
        [Authorize]
        public async Task<IActionResult> UpdateAddressByUser([FromBody] UpdateAddressByUserCommand rq)
        {
            _logger.LogInformation($"Update Address by User request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Update Address by User request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/address/register-address-default")]
        [Authorize]
        public async Task<IActionResult> RegisterAddressDefault([FromBody] RegisterAddressDefaultComand rq)
        {
            _logger.LogInformation($"Register Address default request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Register Address default request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Sport
        [HttpPost("/sport/create")]
        [Authorize]
        public async Task<IActionResult> CreateSport([FromBody] CreateSportCommand rq)
        {
            _logger.LogInformation($"Create Sport request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Create Sport request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/sport/get-all")]
        public async Task<IActionResult> GetAllSport([FromQuery] GetAllSportQuery rq)
        {
            _logger.LogInformation($"Get all Sport request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get all Sport request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region CityDistrictWard
        [HttpGet("/show-all-city")]
        public async Task<IActionResult> GetAllCity([FromQuery] GetAllCityQuery rq)
        {
            _logger.LogInformation($"Get all city request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get all city request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/show-all-district-in-city")]
        public async Task<IActionResult> GetAllDistrict([FromQuery] GetAllDistrictInCityQuery rq)
        {
            _logger.LogInformation($"Get all district in city request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get all district in city request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/show-all-ward-in-district")]
        public async Task<IActionResult> GetAllWard([FromQuery] GetAllWardInDistrictQuery rq)
        {
            _logger.LogInformation($"Get all ward in district request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get all ward in district request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Voucher
        [HttpPost("/voucher/create")]
        [Authorize]
        public async Task<IActionResult> CreateVoucher([FromBody] CreateVoucherCommand rq)
        {
            _logger.LogInformation($"Create Voucher request is: {rq}");
            try
            {
                rq.CreatedBy = GetUsernameFromContext();
                rq.CreatedDate = DateTime.Now;
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Create Voucher request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/voucher/show-all-voucher-valid")]
        [Authorize]
        public async Task<IActionResult> ShowAllVoucherValid([FromQuery] ShowAllVoucherValidQuery rq)
        {
            _logger.LogInformation($"Show all voucher valid request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Show all voucher valid request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("/voucher/add-voucher-to-shoppingcart")]
        [Authorize]
        public async Task<IActionResult> Handle(AddVoucherToShoppingCartCommand rq)
        {
            _logger.LogInformation($"Add voucher to shopingCart request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Add voucher to shopingCart request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/voucher/delete-voucher-for-shoppingcart")]
        [Authorize]
        public async Task<IActionResult> DeleteVoucherForCart([FromBody] DeleteVoucherForCartCommand rq)
        {
            _logger.LogInformation($"delete voucher to shopingCart request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"delete voucher to shopingCart request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region ShoppingCart
        [HttpPost("/add-product-to-shopping-cart")]
        [Authorize]
        public async Task<IActionResult> AddProductToShoppingCart([FromBody] AddProductToShoppingCartCommand rq)
        {
            _logger.LogInformation($"Add Product to ShoppingCart request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Add Product to ShoppingCart request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("/delete-product-to-shopping-cart")]
        [Authorize]
        public async Task<IActionResult> DeleteProductToShoppingCart([FromBody] DeleteProductToShopingCartCommand rq)
        {
            _logger.LogInformation($"Delete Product to ShoppingCart request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Delete Product to ShoppingCart request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/view-shoppingcart-by-user")]
        [Authorize]
        public async Task<IActionResult> ViewShoppingCart([FromQuery] ViewShoppingCartByUserQuery rq)
        {
            _logger.LogInformation($"View ShoppingCart request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"View ShoppingCart request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/get-total-money-in-shoppingCart")]
        [Authorize]
        public async Task<IActionResult> GetTotalMoneyInShoppingCart([FromQuery] GetTotalMoneyInShoppingCartQuery rq)
        {
            _logger.LogInformation($"Get total Money in shopping cart request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get total Money in shopping cart request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/get-Information-default")]
        [Authorize]
        public async Task<IActionResult> GetInformationDefault([FromQuery] GetInformationDefaultQuery rq)
        {
            _logger.LogInformation($"Get information default request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get information default request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/get-bill")]
        [Authorize]
        public async Task<IActionResult> GetBill([FromQuery] GetShoppingOrderQuery rq)
        {
            _logger.LogInformation($"Get bill request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get bill request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/get-all-bill-history")]
        [Authorize]
        public async Task<IActionResult> GetHitoryBill([FromQuery] ViewAllTransactionHistoryQuery rq)
        {
            _logger.LogInformation($"View All Transaction History request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"View All Transaction History request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("/search-and-detail-bill")]
        [Authorize]
        public async Task<IActionResult> SearchDetailBill([FromQuery] SearchAndDetailBillQuery rq)
        {
            _logger.LogInformation($"Search and Detail Bill request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Search and Detail Bill request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("/confirm-status-order")]
        [Authorize]
        public async Task<IActionResult> ConfirmStatusOrder([FromBody] ConfirmShoppingOrderCommand rq)
        {
            _logger.LogInformation($"Confirm status order request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Confirm status order request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("/cancel-order")]
        [Authorize]
        public async Task<IActionResult> CanceledOrder([FromBody] CanceledOrderCommand rq)
        {
            _logger.LogInformation($"Cancel order request is: {rq}");
            try
            {
                var res = await _mediator.Send(rq);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Cancel order request is fail: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
