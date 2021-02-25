using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services;
using Edmund.API.Domain.Services.Communications;
using Edmund.API.Extensions;
using Edmund.API.Resources.EducationalStage;
using Edmund.API.Resources.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = await _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }
        [SwaggerOperation(
            Summary = "List of all Users",
            Description = "List of all Users")]
        [SwaggerResponse(200, "List of all Users", typeof(UserResource))]
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }



        [SwaggerOperation(
            Summary = "Details of an User",
            Description = "Details of an User")]
        [SwaggerResponse(200, "Details of an User", typeof(UserResource))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            var result = await _userService.GetByIdAsync(userId);

            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [SwaggerOperation(
            Summary = "Add a User",
            Description = "Add a User")]
        [SwaggerResponse(200, "Add a User", typeof(UserResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [SwaggerOperation(
            Summary = "Delete a User",
            Description = "Delete a User")]
        [SwaggerResponse(200, "Delete a User", typeof(UserResource))]
        [HttpDelete("userId")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            var result = await _userService.DeleteAsync(userId);

            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [SwaggerOperation(
            Summary = "Edit User data ",
            Description = "Edit Use data given its id")]
        [SwaggerResponse(200, "Edit User data", typeof(IEnumerable<UserResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveUserResource resource)
        {
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(userId, user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}

