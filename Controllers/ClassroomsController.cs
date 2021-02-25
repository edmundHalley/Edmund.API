using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services;
using Edmund.API.Domain.Services.Communications;
using Edmund.API.Extensions;
using Edmund.API.Resources.Classroom;
using Edmund.API.Resources.Mark;
using Edmund.API.Resources.Subject;
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
    public class ClassroomsController : ControllerBase
    {
        private readonly IClassroomService _classroomService;
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;
        private readonly IMarkService _markService;
        private readonly IMapper _mapper;
        
        public ClassroomsController(IClassroomService classroomService, ISubjectService subjectService, IUserService userService, IMarkService  markService, IMapper mapper)
        {
            _classroomService = classroomService;
            _userService = userService;
            _subjectService = subjectService;
            _markService = markService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List of All Classrooms",
            Description = "List of All Classrooms")]
        [SwaggerResponse(200, "List of All Classrooms", typeof(ClassroomResource))]
        [HttpGet]
        public async Task<IEnumerable<ClassroomResource>> GetAllAsync()
        {
            var classrooms = await _classroomService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Classroom>, IEnumerable<ClassroomResource>>(classrooms);
            return resources;
        }

        [SwaggerOperation(
            Summary = "List of Subjects in Classroom",
            Description = "List of Subjects in Classroom")]
        [SwaggerResponse(200, "List of Subjects in Classroom", typeof(SubjectResource))]
        [HttpGet("{classroomId}/subjects")]
        public async Task<IEnumerable<SubjectResource>> GetAllSubjectsAsync(int classroomId)
        {
            var result = await _subjectService.ListSubjectClassroomsAsync(classroomId);
            var subjectsResource = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectResource>>(result);
            return subjectsResource;
        }

        [SwaggerOperation(
            Summary = "List of Students in Classroom",
            Description = "List of Students in Classroom")]
        [SwaggerResponse(200, "List of Students in Classroom", typeof(UserResource))]
        [HttpGet("{classroomId}/users")]
        public async Task<IEnumerable<UserResource>> GetAllStudentsAsync(int classroomId)
        {
            var result = await _userService.ListClassroomUsersAsync(classroomId);
            var studentsResource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(result);
            return studentsResource;
        }

        [SwaggerOperation(
            Summary = "List of Student's Marks by Classroom And Subject",
            Description = "List of Student's Marks by Classroom And Subject")]
        [SwaggerResponse(200, "List of Student's Marks by Classroom And Subject", typeof(MarkResource))]
        [HttpGet("{classroomId}/subjects/{subjectId}/marks")]
        public async Task<IEnumerable<MarkResource>> GetAllMarksByClassroomIdAnsSubjectIdAsync(int classroomId, int subjectId)
        {
            var result = await _markService.ListByClassroomIdAndSubjectIdAsync(classroomId, subjectId);
            var marksResource = _mapper.Map<IEnumerable<Mark>, IEnumerable<MarkResource>>(result);
            return marksResource;
        }

        [SwaggerOperation(
            Summary = "Add a Classroom",
            Description = "Add a Classroom given its properties")]
        [SwaggerResponse(200, "Add a Classroom", typeof(ClassroomResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClassroomResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var classroom = _mapper.Map<SaveClassroomResource, Classroom>(resource);
            var result = await _classroomService.SaveAsync(classroom);

            if (!result.Success)
                return BadRequest(result.Message);

            var classroomResource = _mapper.Map<Classroom, ClassroomResource>(result.Resource);
            return Ok(classroomResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Classroom",
            Description = "Delete a Classroom given its id")]
        [SwaggerResponse(200, "Delete a Classroom", typeof(ClassroomResource))]
        [HttpDelete("{classroomId}")]
        public async Task<IActionResult> DeleteAsync(int classroomId)
        {
            var result = await _classroomService.DeleteAsync(classroomId);

            if (!result.Success)
                return BadRequest(result.Message);
            var classroomResource = _mapper.Map<Classroom, ClassroomResource>(result.Resource);
            return Ok(classroomResource);
        }

        [SwaggerOperation(
            Summary = "Edit Classroom data ",
            Description = "Edit Classroom data given its id")]
        [SwaggerResponse(200, "Edit Classroom data", typeof(IEnumerable<ClassroomResource>))]
        [ProducesResponseType(typeof(IEnumerable<ClassroomResource>), 200)]
        [HttpPut("{classroomId}")]
        public async Task<IActionResult> PutAsync(int classroomId, [FromBody] SaveClassroomResource resource)
        {
            var classroom = _mapper.Map<SaveClassroomResource, Classroom>(resource);
            var result = await _classroomService.UpdateAsync(classroomId, classroom);

            if (!result.Success)
                return BadRequest(result.Message);

            var classroomResource = _mapper.Map<Classroom, ClassroomResource>(result.Resource);
            return Ok(classroomResource);
        }
    }
}
