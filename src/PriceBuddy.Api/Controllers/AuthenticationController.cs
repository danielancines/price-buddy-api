using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PriceBuddy.Api.Services;
using PriceBuddy.Data.Models;
using PriceBuddy.Data.Repositories;
using PriceBuddy.Utils.Helpers;

namespace PriceBuddy.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController
{
    private TokenService _tokenService;
    private UserRepository _userRepository;
    public AuthenticationController(TokenService tokenService, UserRepository userRepository)
    {
        this._tokenService = tokenService;
        this._userRepository = userRepository;
    }

    [HttpPost]
    [AllowAnonymous]
    public IResult Authenticate(User userParameter)
    {
        var user = this._userRepository.GetByLogin(userParameter.Login, CryptHelper.EncryptString(userParameter.Password));
        if (user == null)
        {
            return Results.BadRequest("Usuário e/ou senha inválidos");
        }
        if (!user.Active) return Results.Unauthorized();

        var token = this._tokenService.GenerateToken(user);
        return Results.Ok(token);
    }
}