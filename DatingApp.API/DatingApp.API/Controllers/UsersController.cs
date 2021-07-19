using AutoMapper;
using DatingApp.API.DTO;
using DatingApp.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository repository;
        private readonly IMapper mapper;

        public UsersController(IDatingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var query = await repository.GetAll();
            var mapping = mapper.Map< List<UserListDto>>(query);
            return Ok(mapping);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int? id)
        {
            if(id == null)
            {
                return BadRequest(new { errors = "The ID is not specified" });
            }
            var query = await repository.GetUser(id.Value);
            if(query == null)
            {
                return NotFound("The User is not found");
            }
            return Ok(query);

        }
        
    }
}
