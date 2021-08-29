using API_FlowersStore.API.Contracts;
using API_FlowersStore.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Controllers
{
    /// <summary>
    /// Контроллер авторизации.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить токен для поставщика.
        /// </summary>
        /// <returns>Токен для доступа к API.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TokenContract), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTokenForProvider(UserCredentials userCredentials)
        {
            var user = await _userService.GetByNameAndPassword(userCredentials.Name, userCredentials.Password);

            if (user != null)
            {
                // List<string> roles = await _userService.GetRoles(provider)
                var roles = new List<string>()
                {
                    new string(user.Role)
                };

                if (roles == null)
                    return BadRequest($"No roles for: {user.Name}");

                var rolesString = String.Join(",", roles);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, rolesString),
                    new Claim("UserId", user.Id.ToString())
                };

                var symmetricSecurityKey = AuthOptions.GetSymmetricSecurityKey();

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256),
                    Audience = AuthOptions.AUDIENCE,
                    Issuer = AuthOptions.ISSUER
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new TokenContract{ Token = tokenString });
            }
            else
            {
                return Unauthorized("Not authorized.");
            }
        }
    }
}
