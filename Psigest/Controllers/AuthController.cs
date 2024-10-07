using Psigest.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psigest.DTO;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Psigest.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthenticate authenticate, IConfiguration configuration) : ControllerBase
{
    private readonly IAuthenticate _authentication = authenticate;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginDTO loginDto)
    {
        var result = await _authentication.AuthenticateAsync(loginDto.Email, loginDto.Password);

        if (result)
        {
            var claims = new[] {
            new Claim("email", loginDto.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = await _authentication.GenerateToken(claims);

            return new UserTokenDTO { Token = token.Value, Expiration = token.ExpirationTime};
        }

        ModelState.AddModelError(string.Empty, "Credenciais Inválidas");

        return BadRequest(ModelState);
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> CreateUser([FromBody] RegisterDTO registerDto)
    {
        var result = await _authentication.RegisterUserAsync(registerDto.Email, registerDto.Password);

        if (result)
        {
            return Ok("Usuário criado com sucesso");
        }

        ModelState.AddModelError(string.Empty, "Não foi possível criar o novo usuário");

        return BadRequest(ModelState);

    }
}
