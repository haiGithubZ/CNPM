using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using JHipsterNet.Core.Pagination.Extensions;
using Jhipster.Domain;
using Jhipster.Security;
using Jhipster.Domain.Services.Interfaces;
using Jhipster.Dto;
using Jhipster.Web.Extensions;
using Jhipster.Web.Filters;
using Jhipster.Web.Rest.Problems;
using Jhipster.Web.Rest.Utilities;
using Jhipster.Crosscutting.Constants;
using Jhipster.Crosscutting.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Jhipster.Dto.Authentication;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Configuration;
using RestSharp;
using SportSvc.Application.DTO;
using Jhipster.Infrastructure.Data;

namespace Jhipster.Controllers
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _log;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDatabaseContext _databaseContext;

        public UsersController(ILogger<UsersController> log, UserManager<User> userManager, IUserService userService,
            IMapper mapper, IMailService mailService,IConfiguration configuration, ApplicationDatabaseContext databaseContext)
        {
            _log = log;
            _userManager = userManager;
            _userService = userService;
            _mailService = mailService;
            _mapper = mapper;
            _configuration = configuration;
            _databaseContext = databaseContext;
        }

        /// <summary>
        /// Tạo tài khoản (admin)
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestAlertException"></exception>
        /// <exception cref="LoginAlreadyUsedException"></exception>
        /// <exception cref="EmailAlreadyUsedException"></exception>
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserDto userDto)
        {
            _log.LogDebug($"REST request to save User : {userDto}");
            if (!string.IsNullOrEmpty(userDto.Id))
                throw new BadRequestAlertException("A new user cannot already have an ID", "userManagement",
                    "idexists");
            // Lowercase the user login before comparing with database
            if (await _userManager.FindByNameAsync(userDto.Login.ToLowerInvariant()) != null)
                throw new LoginAlreadyUsedException();
            if (await _userManager.FindByEmailAsync(userDto.Email.ToLowerInvariant()) != null)
                throw new EmailAlreadyUsedException();

            var newUser = await _userService.CreateUser(_mapper.Map<User>(userDto));
            //if (!string.IsNullOrEmpty(userDto.Email))
            //{
            //    await _mailService.SendCreationEmail(newUser);
            //}

            // Qua sđt chưa xử lý
            if (string.IsNullOrEmpty(userDto.Email) && !string.IsNullOrEmpty(userDto.PhoneNumber))
            {

            }

            return CreatedAtAction(nameof(GetUser), new { login = newUser.Login }, newUser)
                .WithHeaders(HeaderUtil.CreateEntityCreationAlert("userManagement.created", newUser.Login));
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản của tài khoản admin hiện tại (admin)
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        /// <exception cref="EmailAlreadyUsedException"></exception>
        /// <exception cref="LoginAlreadyUsedException"></exception>
        [HttpPut]
        [ValidateModel]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            _log.LogDebug($"REST request to update User : {userDto}");
            var existingUser = await _userManager.FindByEmailAsync(userDto.Email);
            if (existingUser != null && !existingUser.Id.Equals(userDto.Id)) throw new EmailAlreadyUsedException();
            existingUser = await _userManager.FindByNameAsync(userDto.Login);
            if (existingUser != null && !existingUser.Id.Equals(userDto.Id)) throw new LoginAlreadyUsedException();

            var updatedUser = await _userService.UpdateUser(_mapper.Map<User>(userDto));

            return ActionResultUtil.WrapOrNotFound(updatedUser)
                .WithHeaders(HeaderUtil.CreateAlert("userManagement.updated", userDto.Login));
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản của user theo id (admin)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ValidateModel]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDto userDto)
        {
            return await UpdateUser(userDto);
        }

        /// <summary>
        /// Lấy tất cả người dùng (admin) page bắt đầu từ 0
        /// </summary>
        /// <param name="pageable"></param>
        /// <returns></returns>
        [HttpPost("GetAllUser")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> GetAllUsers(int page, int pagesize)
        {
            _log.LogDebug("REST request to get a page of Users");
            var listUser = await _userManager.Users
                .Include(it => it.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(p => p.CreatedDate)
                .ToListAsync();
            var userDtos = listUser.Select(user => _mapper.Map<UserDto>(user));
            UserDtoAdmin value = new()
            {
                TotalCount = userDtos.Count(),
                userDtos = userDtos
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .ToList()
            };
            return Ok(value);

        }

        /// <summary>
        /// Lấy tất cả nhóm quyền hiện tại (admin)
        /// </summary>
        /// <returns></returns>
        [HttpGet("authorities")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public ActionResult<IEnumerable<string>> GetAuthorities()
        {
            return Ok(_userService.GetAuthorities());
        }

        /// <summary>
        /// Lấy thông tin người dùng theo username (login) (admin)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("searchUser")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> SearchUser([FromBody] SearchUserDto dto, int page, int pagesize)
        {
            _log.LogDebug($"REST request to search User : {dto}");
            
            var result = await _userManager.Users
                .OrderByDescending(p => p.CreatedDate)
                .Include(it => it.UserRoles)
                .ThenInclude(r => r.Role)
                .ToListAsync();
            if(dto.IsActived == "True")
            {
                result = result.Where(p => p.Activated == true).ToList();
            }
            else if (dto.IsActived == "False")
            {
                result = result.Where(p => p.Activated == false).ToList();
            }

            if (!string.IsNullOrEmpty(dto.Username))
            {
                result = result.Where(p => p.Login.ToLower().Contains(dto.Username.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(dto.Fullname))
            {
                result = result.Where(p => !string.IsNullOrEmpty(p.FirstName)  && p.FirstName.ToLower().Contains(dto.Fullname.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(dto.Email))
            {
                result = result.Where(p => !string.IsNullOrEmpty(p.Email) && p.Email.ToLower().Contains(dto.Email.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(dto.Phone))
            {
                result = result.Where(p => !string.IsNullOrEmpty(p.PhoneNumber) && p.PhoneNumber.Contains(dto.Phone)).ToList();
            }
            if (!string.IsNullOrEmpty(dto.ReferralCode))
            {
                result = result.Where(p => !string.IsNullOrEmpty(p.ReferralCode) && p.ReferralCode.ToLower().Equals(dto.ReferralCode.ToLower())).ToList();
            }
            DateTime Day = new DateTime(1, 1, 1, 0, 0, 0);
            if (dto.CreateDate != Day)
                result = result.Where(p => p.CreatedDate.ToShortDateString().Equals(dto.CreateDate.ToShortDateString())).ToList();

            var userDto = _mapper.Map<List<UserDto>>(result);
            if (!string.IsNullOrEmpty(dto.Role))
            {
                userDto = userDto.Where(p => p.Roles.Contains(dto.Role)).ToList();
            }
            UserDtoAdmin value = new()
            {
                TotalCount = userDto.Count(),
                userDtos = userDto                  
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize)
                    .ToList()
            };
            return ActionResultUtil.WrapOrNotFound(value);
        }

        /// <summary>
        /// Lấy thông tin người dùng theo username (login) (admin)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("{login}")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> GetUser(string login)
        {
            _log.LogDebug($"REST request to search User : {login}");
            var result = await _userManager.Users
                .Where(user => user.Login == login)
                .Include(it => it.UserRoles)
                .ThenInclude(r => r.Role)
                 .SingleOrDefaultAsync();
            var userDto = _mapper.Map<UserDto>(result);
            return ActionResultUtil.WrapOrNotFound(userDto);


        }

        /// <summary>
        /// Xóa người dùng theo username (login) (admin)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpDelete("{login}")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> DeleteUser([FromRoute] string login)
        {
            _log.LogDebug($"REST request to delete User : {login}");
            await _userService.DeleteUser(login);
            return NoContent().WithHeaders(HeaderUtil.CreateEntityDeletionAlert("userManagement.deleted", login));
        }

        /// <summary>
        /// Đặt lại mật khẩu người dùng theo username (login) (admin)
        /// </summary>
        /// <param name="resetPasswordAdminDTO"></param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        [ValidateModel]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<ActionResult> ResetPasswordAdmin([FromBody] ResetPasswordAdminDTO resetPasswordAdminDTO)
        {
            _log.LogDebug($"REST request to rest Password : {JsonConvert.SerializeObject(resetPasswordAdminDTO)}");
            try
            {
                if (!resetPasswordAdminDTO.NewPassword.Equals(resetPasswordAdminDTO.RePassword)) throw new BadRequestAlertException("Password not mismatch", "RePassword", "");
                await _userService.AdminPasswordReset(resetPasswordAdminDTO.Login, resetPasswordAdminDTO.NewPassword);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("statistics-shop")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> StatisticsShop()
        {
            _log.LogDebug($"REST request statistics shop: ");
            try
            {
                var result = new StatisticsDTO();
                result.Revenue = _databaseContext.Bills.Where(i => i.Status == 2).Sum(i => (i.TotalMoney - i.Ship));
                result.CountProductOfSport = new List<SportDTO>();
                var listSport = await _databaseContext.Sports.ToListAsync();
                foreach(var item in listSport)
                {
                    var temp = new SportDTO()
                    {
                        Name = item.Name,
                        CountProduct = _databaseContext.Products.Where(i => i.SportId == item.Id).Sum(i => i.NumberSold)
                    };
                    result.CountProductOfSport.Add(temp);
                }

                result.ListProductBestSell = await _databaseContext.Products.OrderByDescending(i => i.NumberSold).Take(5).ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                _log.LogInformation($"REST request statistics shop is fail: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("get-revenue-of-time")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IActionResult> GetRevenueOfTime(int? Month, int Year)
        {
            _log.LogDebug($"REST request get revenue of time: ");
            try
            {
                if(string.IsNullOrEmpty(Month.ToString()))
                {
                    var venue = _databaseContext.Bills.Where(i => i.Status == 2 && i.CreatedDate.Year == Year).Sum(i => (i.TotalMoney - i.Ship));
                    return Ok(venue);
                }
                else
                {
                    var venue = _databaseContext.Bills.Where(i => i.Status == 2 && i.CreatedDate.Year == Year && i.CreatedDate.Month == Month).Sum(i => (i.TotalMoney - i.Ship));
                    return Ok(venue);
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"REST request get revenue of time is fail: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}
