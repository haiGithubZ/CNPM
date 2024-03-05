using Jhipster.Dto;
using Jhipster.Security.Jwt;
using Jhipster.Domain.Services.Interfaces;
using Jhipster.Web.Extensions;
using Jhipster.Web.Filters;
using Jhipster.Crosscutting.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Jhipster.Domain;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;

namespace Jhipster.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserJwtController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenProvider _tokenProvider;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserJwtController(IAuthenticationService authenticationService, ITokenProvider tokenProvide
            ,UserManager<User> userManager,IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _tokenProvider = tokenProvide;
            _userManager = userManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Đăng nhập với username/password
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        [ValidateModel]
        public async Task<ActionResult<JwtToken>> Authorize([FromBody] LoginDto loginDto)
        {
            var user = await _authenticationService.Authenticate(loginDto.Username, loginDto.Password);
            var rememberMe = loginDto.RememberMe;
            var jwt = await _tokenProvider.CreateToken(user, rememberMe);
            var httpHeaders = new HeaderDictionary
            {
                [JwtConstants.AuthorizationHeader] = $"{JwtConstants.BearerPrefix} {jwt}",
            };
            return Ok(new JwtToken(jwt)).WithHeaders(httpHeaders);
        }
    }

    public class JwtToken
    {
        public JwtToken(string idToken)
        {
            IdToken = idToken;
        }

        [JsonProperty("id_token")] private string IdToken { get; }
    }
}
