using System.Security.Claims;
using Authentication.Services.Data.Models;
using Authentication.Services.Data.Repository;
using Authentication.Services.Tokens;
using Authorization.Services.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{    
    private IHttpContextAccessor _httpContextAccessor;
    private TokenRepository tokenRepository;
    private UserRepository repository;
    private GroupUserRepository groupUserRepository;
    public HomeController(IHttpContextAccessor httpContextAccessor)
    {
        tokenRepository = new TokenRepository();
        repository = new UserRepository();
        groupUserRepository = new GroupUserRepository();
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("/")]
    [AllowAnonymous]
    public ActionResult<string> HelloWorld() => Ok("Hello World!");

    [HttpPost("/login")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> LoginAsync([FromHeader] string email) 
    {
        Usuario usuario = await repository.GetByEmail(email);
        List<UsuarioGroup> usuarioGroups = await groupUserRepository.GetGroupsByUsuarioId(usuario.Id);

        string token = MainTokenServices.GenerateToken(usuario.Id);

        Claim claim = new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString());
        Claim claim2 = new Claim(ClaimTypes.Name, token);
        List<Claim> claims = [
            claim,
            claim2
        ];

        foreach(var item in usuarioGroups) 
        {
            Console.WriteLine($"{item.GroupId} {item.Role}");
            Claim claim3 = new Claim($"GroupRole-{item.GroupId}", item.Role!);
            claims.Add(claim3);
        }

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        tokenRepository.Create(usuario.Id, token);

        await _httpContextAccessor.HttpContext!.SignInAsync("CookieAuth", claimsPrincipal);

        return Ok("Logado");
    }

    [HttpPost("/logout")]
    [Authorize]
    public async Task<ActionResult<string>> LogoutAsync()
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync("CookieAuth");

        return Ok("Deslogado!");
    }

    [HttpGet("/usuarioLogado")]
    public ActionResult<string> UsuarioLogado() 
    {
        if(!_httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated) 
        {
            return Unauthorized();
        }

        return Ok(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }

    
    [HttpGet("/GroupAuthorization")]
    public ActionResult<string> GroupAuthorization([FromHeader] string groupId) 
    {
        // Meu problema provavelmente está nesse If....
        if(_httpContextAccessor.HttpContext!.User.FindFirst($"GroupRole-{groupId}")!.Value != "Professor") 
        {
            return Unauthorized();
        }

        Console.WriteLine("Autorizado!");

        return Ok("Professor Autorizado!");
    }
}