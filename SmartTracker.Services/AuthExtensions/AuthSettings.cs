namespace SmartTracker.Services.AuthExtensions;

public class AuthSettings
{
    public required string Issuer { get; set; }
    public required TimeSpan ExpiresIn { get; set; }
    public required string Secretkey { get; set; }
}