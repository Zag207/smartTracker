using Microsoft.Extensions.Primitives;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Abstractions;

public interface IJwtService
{
    public string GenerateToken(User user);
    public bool TryExtractTokenFromHeader(StringValues header, out string token);
    public Dictionary<string, string> GetClaimsFromToken(string token);
}