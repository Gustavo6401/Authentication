using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Services.Tokens;

public class MainTokenServices 
{
    public static string GenerateToken(Guid userId) 
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(MainTokenSettings.Secret);

        var claimsIdentity = new ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        }, "CookieAuth");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddDays(90),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var resp = tokenHandler.CreateToken(tokenDescriptor);
        string token = tokenHandler.WriteToken(resp);

        return token;
    }
}