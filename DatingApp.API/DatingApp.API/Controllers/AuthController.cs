using DatingApp.API.DTO;
using DatingApp.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserDTO loginUserDTO)
        {
            
            var userResult = await _authRepository.Login(loginUserDTO.UserName, loginUserDTO.Password);
            if (userResult == null)
                return Unauthorized();

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userResult.UserName),
                new Claim(ClaimTypes.Email , userResult.Email),
                new Claim(ClaimTypes.NameIdentifier, userResult.ID.ToString()),
                new Claim(ClaimTypes.MobilePhone, userResult.Phone)
            };
            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes((_configuration["AppSettings:Token"].ToString())));
            var signer = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDecrptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = signer
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDecrptor);


            return Ok(new { token = tokenHandler.WriteToken(token)});
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            if (!await _authRepository.UserExist(registerUserDTO.UserName))
            {
                return BadRequest("The user already exist");
            }

          var userResult = await  _authRepository.Registration(new AppUser()
            {
                Email = registerUserDTO.Email,
                Phone = registerUserDTO.Phone,
                IsDeleted = false,
                UserName = registerUserDTO.UserName
            }, registerUserDTO.Password);


            return StatusCode(201);
        }
    }
}
