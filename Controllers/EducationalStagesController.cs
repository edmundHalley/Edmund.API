using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services;
using Edmund.API.Extensions;
using Edmund.API.Resources.Classroom;
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
    public class EducationalStagesController : ControllerBase
    {
        private readonly IEducationalStageService _educationalStageService;
        private readonly IClassroomService _classroomService;
        private readonly IMapper _mapper;

        public EducationalStagesController(IEducationalStageService educationalStageService, IClassroomService classroomService, IMapper mapper)
        {
            _educationalStageService = educationalStageService;
            _classroomService = classroomService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List of Educational Stages",
            Description = "List of Educational Stages")]
        [SwaggerResponse(200, "List of Educational Stage", typeof(EducationalStageResource))]
        [HttpGet]
        public async Task<IEnumerable<EducationalStageResource>> GetAllAsync()
        {
            var educationalStage = await _educationalStageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<EducationalStage>, IEnumerable<EducationalStageResource>>(educationalStage);
            return resources;
        }

        [SwaggerOperation(
            Summary = "List of Classrooms per Educational Stages",
            Description = "List of Classrooms per Educational Stages")]
        [SwaggerResponse(200, "List of Classrooms per Educational Stage", typeof(ClassroomResource))]
        [HttpGet("{educationalStageId}")]
        public async Task<IEnumerable<ClassroomResource>> GetAllStudentsAsync(int educationalStageId)
        {
            var result = await _classroomService.ListEducationalStageClassroomsAsync(educationalStageId);
            var classroomsResource = _mapper.Map<IEnumerable<Classroom>, IEnumerable<ClassroomResource>>(result);
            return classroomsResource;
        }


        [SwaggerOperation(
            Summary = "Add an Educational Stage",
            Description = "Add an Educational Stage given its properties")]
        [SwaggerResponse(200, "Add an Educational Stage", typeof(EducationalStageResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEducationalStageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var educationalStage = _mapper.Map<SaveEducationalStageResource, EducationalStage>(resource);
            var result = await _educationalStageService.SaveAsync(educationalStage);

            if (!result.Success)
                return BadRequest(result.Message);

            var educationalStageResource = _mapper.Map<EducationalStage, EducationalStageResource>(result.Resource);
            return Ok(educationalStageResource);
        }

        [SwaggerOperation(
            Summary = "Delete an Educational Stage",
            Description = "Delete an Educational Stage given its id")]
        [SwaggerResponse(200, "Delete an Educational Stage", typeof(EducationalStageResource))]
        [HttpDelete("{educationalStageId}")]
        public async Task<IActionResult> DeleteAsync(int educationalStageId)
        {
            var result = await _educationalStageService.DeleteAsync(educationalStageId);

            if (!result.Success)
                return BadRequest(result.Message);
            var educationalStageResource = _mapper.Map<EducationalStage, EducationalStageResource>(result.Resource);
            return Ok(educationalStageResource);
        }

        [SwaggerOperation(
            Summary = "Edit Educational Stage data ",
            Description = "Edit Educational Stage data given its id")]
        [SwaggerResponse(200, "Edit Educational Stage data", typeof(IEnumerable<EducationalStageResource>))]
        [ProducesResponseType(typeof(IEnumerable<EducationalStageResource>), 200)]
        [HttpPut("{educationalStageId}")]
        public async Task<IActionResult> PutAsync(int educationalStageId, [FromBody] SaveEducationalStageResource resource)
        {
            var educationalStage = _mapper.Map<SaveEducationalStageResource, EducationalStage>(resource);
            var result = await _educationalStageService.UpdateAsync(educationalStageId, educationalStage);

            if (!result.Success)
                return BadRequest(result.Message);

            var educationalStageResource = _mapper.Map<EducationalStage, EducationalStageResource>(result.Resource);
            return Ok(educationalStageResource);
        }
    }
}
