using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services;
using Edmund.API.Extensions;
using Edmund.API.Resources.Mark;
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
    [Route("api/users")]
    [ApiController]
    public class UserSubjectsController : ControllerBase
    {
        private readonly IUserSubjectService _userSubjectService;
        private readonly IMarkService _markService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserSubjectsController(IUserSubjectService userSubjectService, IMarkService markService, IUserService userService, IMapper mapper)
        {
            _userSubjectService = userSubjectService;
            _markService = markService;
            _userService = userService;
            _mapper = mapper;
        }
        

       [SwaggerOperation(
            Summary = "List of Subjects given a userId",
            Description = "List of Subjects given a userId")]
        [SwaggerResponse(200, "List of Subjects given a userId", typeof(UserSubjectResource))]
        [HttpGet("{userId}/subjects")]
        public async Task<IEnumerable<UserSubjectResource>> GetAllSubjectsByUserIdAsync(int userId)
        {
            var result = await _userSubjectService.ListByUserIdAsync(userId);
            var userSubjectResource = _mapper.Map<IEnumerable<UserSubject>, IEnumerable<UserSubjectResource>>(result);
            return userSubjectResource;
        }

        [SwaggerOperation(
            Summary = "List of all Students Marks in a Subject",
            Description = "List of all Students Marks in a Subject")]
        [SwaggerResponse(200, "List of all Students Marks in a Subject", typeof(MarkResource))]
        [HttpGet("{userId}/subjects/{subjectId}/marks")]
        public async Task<IEnumerable<MarkResource>> GetAllMarksByUserIdAndSubjectIdAsync(int userId, int subjectId)
        {
            var marks = await _markService.ListByUserIdAndSubjectIdAsync(userId, subjectId);
            var resources = _mapper.Map<IEnumerable<Mark>, IEnumerable<MarkResource>>(marks);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Assign a User to a Subject",
            Description = "Assign a User to a Subject")]
        [SwaggerResponse(200, "User was assigned to Subject", typeof(UserSubjectResource))]
        [HttpPost("{userId}")]
        public async Task<IActionResult> AssignProductTag(int subjectId, int userId)
        {
            var result = await _userSubjectService.AssignUserSubjectAsync(subjectId, userId);
            if (!result.Success)
                return BadRequest(result.Message);
            User user = _userService.GetByIdAsync(userId).Result.Resource;
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        [SwaggerOperation(
            Summary = "Unassign a User to a Subject",
            Description = "Unassign a User to a Subject")]
        [SwaggerResponse(200, "User was unassigned to Subject", typeof(UserSubjectResource))]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> UnassignProductTag(int subjectId, int userId)
        {
            var result = await _userSubjectService.UnassignUserSubjectAsync(subjectId, userId);
            if (!result.Success)
                return BadRequest(result.Message);
            User user = _userService.GetByIdAsync(userId).Result.Resource;
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        [SwaggerOperation(
            Summary = "Add a Mark",
            Description = "Add a Mark")]
        [SwaggerResponse(200, "Add a Mark", typeof(MarkResource))]
        [HttpPost("{teacherId}/subjects/{subjectId}/users/{studentId}")]
        public async Task<IActionResult> PostAsync(int teacherId, int subjectId, int studentId, [FromBody] SaveMarkResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var mark = _mapper.Map<SaveMarkResource, Mark>(resource);
            var result = await _markService.SaveAsync(teacherId, subjectId, studentId, mark);

            if (!result.Success)
                return BadRequest(result.Message);

            var markResource = _mapper.Map<Mark, MarkResource>(result.Resource);
            return Ok(markResource);
        }

        [SwaggerOperation(
            Summary = "Edit Mark data ",
            Description = "Edit Mark data given its id")]
        [SwaggerResponse(200, "Edit Mark data", typeof(IEnumerable<MarkResource>))]
        [ProducesResponseType(typeof(IEnumerable<MarkResource>), 200)]
        [HttpPut("{teacherId}/subjects/{subjectId}/users/{studentId}/mark/{markId}")]
        public async Task<IActionResult> PutAsync(int teacherId, int subjectId, int studentId, int markId, [FromBody] SaveMarkResource resource)
        {
            var mark = _mapper.Map<SaveMarkResource, Mark>(resource);
            var result = await _markService.UpdateAsync(teacherId, subjectId, studentId, markId, mark);

            if (!result.Success)
                return BadRequest(result.Message);

            var markResource = _mapper.Map<Mark, MarkResource>(result.Resource);
            return Ok(markResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Mark",
            Description = "Delete a Mark")]
        [SwaggerResponse(200, "Delete a Mark", typeof(MarkResource))]
        [HttpDelete("{teacherId}/subjects/{subjectId}/users/{studentId}/marks/{markId}")]
        public async Task<IActionResult> DeleteAsync(int teacherId, int subjectId, int studentId, int markId)
        {
            var result = await _markService.DeleteAsync(teacherId, subjectId, studentId, markId);

            if (!result.Success)
                return BadRequest(result.Message);
            var markResource = _mapper.Map<Mark, MarkResource>(result.Resource);
            return Ok(markResource);
        }
    }
}
