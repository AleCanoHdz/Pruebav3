using Azure;
using JWT.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pruebav3.Data;
using Pruebav3.DTOs;
using Pruebav3.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Pruebav3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registro")]
        public async Task<ActionResult<ServiceResponse<int>>> Registro(UserDto request)
        {
            var log = await _userService.Registro(new Login { Name = request.Name }, request.Password);

            return Ok(log);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var log = await _userService.Login(request.Name, request.Password);
            
            return Ok(log);
        }
    }
}
