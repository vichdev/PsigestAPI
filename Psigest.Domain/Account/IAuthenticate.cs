using Psigest.Domain.Entities;
using System.Security.Claims;

namespace Psigest.Domain.Account;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> RegisterUserAsync(string email, string password);
    Task<UserToken> GenerateToken(IEnumerable<Claim> claims);
    Task LogoutAsync();
}