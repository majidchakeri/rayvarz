using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using rayverz.Data.Entities;

namespace rayverz.Services.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private User _user;

        public AuthManager(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        public async Task<string> CreateToken()
        {
            var signingCredential = GetSigningCredential();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredential, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            _user = await _userManager.FindByNameAsync(username);
            return _user != null && await _userManager.CheckPasswordAsync(_user, password);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredential, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWTConfigs");
            var expireTime = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings.GetSection("expire").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("issuer").Value,
                claims: claims,
                expires: expireTime,
                signingCredentials: signingCredential
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };



            return claims;
        }

        private SigningCredentials GetSigningCredential()
        {
            var key = _configuration.GetSection("JWTConfigs:key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
