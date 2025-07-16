namespace SmartTracker.Services.Abstractions;

public interface IAuthService
{
    public Task Register(string name, string surname, string userName, string password);
    public Task<string> Login(string username, string password);
}