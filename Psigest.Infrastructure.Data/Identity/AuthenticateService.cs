using Psigest.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Psigest.Infrastructure.Data.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Psigest.Domain.Entities;

namespace Psigest.Infrastructure.Data.Identity;

public class AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

        return result.Succeeded;
    }

    public async Task<bool> RegisterUserAsync(string email, string password)
    {
        var applicationUser = new ApplicationUser { UserName = email, Email = email };

        var result = _userManager.CreateAsync(applicationUser, password).Result;

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(applicationUser, isPersistent: false);
        }

        return result.Succeeded;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<UserToken> GenerateToken(IEnumerable<Claim> claims)
    {
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expirationTime = DateTime.UtcNow.AddMinutes(10);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expirationTime,
            signingCredentials: credentials
        );

        return new UserToken(new JwtSecurityTokenHandler().WriteToken(token), expirationTime);
    }

}