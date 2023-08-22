using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Implementations
{
    #region Constructor 
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Trainee> _userManager;

        public TokenGenerator(IConfiguration configuration, UserManager<Trainee> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        #endregion
        #region Implimentation
        public async Task<string> GenerateTokenAsync(Trainee user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName",user.LastName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signingKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["JWTSettings:SecretKey"]));
            var token = new JwtSecurityToken(audience: _configuration["JWTSettings:Audience"],
                issuer: _configuration["JWTSettings:Issuer"],
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
