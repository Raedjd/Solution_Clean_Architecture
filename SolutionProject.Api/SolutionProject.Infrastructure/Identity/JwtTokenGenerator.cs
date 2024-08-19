using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SolutionProject.Application.Contracts.Identity;
using SolutionProject.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace SolutionProject.Infrastructure.Identity
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettingsOptions)
        {
            _jwtSettings = jwtSettingsOptions.Value;
        }

        public string GenerateToken(User user, string role)
        {
            var claims = new List<Claim>
       {
           new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.Sub, user.FirstName+ " "+ user.LastName),
           new Claim(ClaimTypes.Email, user.Email ),
           new Claim(ClaimTypes.Role, user.Role.Name )
       };
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return  accessToken;
        }
    }
}
