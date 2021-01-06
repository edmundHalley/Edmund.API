using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using Edmund.API.Extensions;
using Edmund.API.Resources.Subject;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List of all Subjects",
            Description = "List of all Subjects")]
        [SwaggerResponse(200, "List of all Subjects", typeof(SubjectResource))]
        [HttpGet]
        public async Task<IEnumerable<SubjectResource>> GetAllAsync()
        {
            var subjects = await _subjectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectResource>>(subjects);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Details of a Subject",
            Description = "Details of a Subject")]
        [SwaggerResponse(200, "Details of a Subject", typeof(SubjectResource))]
        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetByIdAsync(int subjectId)
        {
            var result = await _subjectService.GetByIdAsync(subjectId);

            if (!result.Success)
                return BadRequest(result.Message);
            var markResource = _mapper.Map<Subject, SubjectResource>(result.Resource);
            return Ok(markResource);
        }

        [SwaggerOperation(
            Summary = "Add a Subject",
            Description = "Add a Subject")]
        [SwaggerResponse(200, "Add a Subject", typeof(SubjectResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subject = _mapper.Map<SaveSubjectResource, Subject>(resource);
            var result = await _subjectService.SaveAsync(subject);

            if (!result.Success)
                return BadRequest(result.Message);

            var subjectResource = _mapper.Map<Subject, SubjectResource>(result.Resource);
            return Ok(subjectResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Subject",
            Description = "Delete a Subject")]
        [SwaggerResponse(200, "Delete a Subject", typeof(SubjectResource))]
        [HttpDelete("subjectId")]
        public async Task<IActionResult> DeleteAsync(int subjectId)
        {
            var result = await _subjectService.DeleteAsync(subjectId);

            if (!result.Success)
                return BadRequest(result.Message);
            var subjectResource = _mapper.Map<Subject, SubjectResource>(result.Resource);
            return Ok(subjectResource);
        }

        [SwaggerOperation(
            Summary = "Edit Subject data ",
            Description = "Edit Subject data given its id")]
        [SwaggerResponse(200, "Edit Subject data", typeof(IEnumerable<SubjectResource>))]
        [ProducesResponseType(typeof(IEnumerable<SubjectResource>), 200)]
        [HttpPut("{subjectId}")]
        public async Task<IActionResult> PutAsync(int subjectId, [FromBody] SaveSubjectResource resource)
        {
            var subject = _mapper.Map<SaveSubjectResource, Subject>(resource);
            var result = await _subjectService.UpdateAsync(subjectId, subject);

            if (!result.Success)
                return BadRequest(result.Message);

            var subjectResource = _mapper.Map<Subject, SubjectResource>(result.Resource);
            return Ok(subjectResource);
        }

    }
}
