using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using SmartTracker.Services.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.AuthExtensions;

public class JwtService(IOptions<AuthSettings> options) : IJwtService
{
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name),
        };

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(options.Value.ExpiresIn),
            issuer: options.Value.Issuer,
            audience: options.Value.Issuer,
            claims: claims,
            notBefore: DateTime.UtcNow,
            signingCredentials: 
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(options.Value.Secretkey)),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            );
        
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }

    public bool TryExtractTokenFromHeader(StringValues authHeader, out string token)
    {
        token = "";
        string header = authHeader[0];
        
        if (header == StringValues.Empty || !header.Contains("Bearer"))
        {
            return false;
        }
        
        token = header.Split(" ")[1];
        return true;
    }

    public Dictionary<string, string> GetClaimsFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        
        return jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value);
    }
}