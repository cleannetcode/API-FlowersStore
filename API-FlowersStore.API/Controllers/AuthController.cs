using API_FlowersStore.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        /// <summary>
        /// Получить токен для поставщика.
        /// </summary>
        /// <returns>Токен для доступа к API.</returns>
        [HttpPost]
        public async Task<IActionResult> GetTokenForProvider(ProviderCredentials providerCredentials)
        {
            //var provider = await _providerService.GetProvider();
            var provider = new { Id = 1, Name = "Пятерочка", Password = "555" };

            if (provider != null)
            {
                // List<string> roles = await _providerService.GetRoles(provider)
                var roles = new List<string>()
                {
                    new string("Provider")
                };

                if (roles == null)
                    return BadRequest($"No roles for: {provider.Name}");

                var rolesString = String.Join(",", roles);

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, provider.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, rolesString)
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

                return Ok(new { Token = tokenString });
            }


            throw new NotImplementedException();
        }
    }
}
