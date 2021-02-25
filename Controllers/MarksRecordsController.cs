using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services;
using Edmund.API.Extensions;
using Edmund.API.Resources.MarksRecord;
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
    public class MarksRecordsController : ControllerBase
    {
        private readonly IMarksRecordService _marksRecordService;
        private readonly IMapper _mapper;

        public MarksRecordsController(IMarksRecordService marksRecordService, IMapper mapper)
        {
            _marksRecordService = marksRecordService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List of All Marks Record",
            Description = "List of All Marks Record")]
        [SwaggerResponse(200, "List of Marks Record", typeof(MarksRecordResource))]
        [HttpGet]
        public async Task<IEnumerable<MarksRecordResource>> GetAllAsync()
        {
            var marksRecords = await _marksRecordService.ListAsync();
            var resources = _mapper.Map<IEnumerable<MarksRecord>, IEnumerable<MarksRecordResource>>(marksRecords);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Details of a Marks Record",
            Description = "Details of a Marks Record")]
        [SwaggerResponse(200, "Details of a Marks Record", typeof(MarksRecordResource))]
        [HttpGet("{marksRecordId}")]
        public async Task<IActionResult> GetByIdAsync(int marksRecordId)
        {
            var result = await _marksRecordService.GetByIdAsync(marksRecordId);

            if (!result.Success)
                return BadRequest(result.Message);
            var marksRecordResource = _mapper.Map<MarksRecord, MarksRecordResource>(result.Resource);
            return Ok(marksRecordResource);
        }

        [SwaggerOperation(
            Summary = "Add a Marks Record",
            Description = "Add a Marks Record")]
        [SwaggerResponse(200, "Add a Marks Record", typeof(MarksRecordResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMarksRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var marksRecords = _mapper.Map<SaveMarksRecordResource, MarksRecord>(resource);
            var result = await _marksRecordService.SaveAsync(marksRecords);

            if (!result.Success)
                return BadRequest(result.Message);

            var marksRecordResource = _mapper.Map<MarksRecord, MarksRecordResource>(result.Resource);
            return Ok(marksRecordResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Marks Record",
            Description = "Delete a Marks Record")]
        [SwaggerResponse(200, "Delete a Marks Record", typeof(MarksRecordResource))]
        [HttpDelete("marksRecordId")]
        public async Task<IActionResult> DeleteAsync(int marksRecordId)
        {
            var result = await _marksRecordService.DeleteAsync(marksRecordId);

            if (!result.Success)
                return BadRequest(result.Message);
            var marksRecordResource = _mapper.Map<MarksRecord, MarksRecordResource>(result.Resource);
            return Ok(marksRecordResource);
        }

        [SwaggerOperation(
            Summary = "Edit Marks Record data ",
            Description = "Edit Marks Record data given its id")]
        [SwaggerResponse(200, "Edit Marks Record data", typeof(IEnumerable<MarksRecordResource>))]
        [ProducesResponseType(typeof(IEnumerable<MarksRecordResource>), 200)]
        [HttpPut("{marksRecordId}")]
        public async Task<IActionResult> PutAsync(int marksRecordId, [FromBody] SaveMarksRecordResource resource)
        {
            var marksRecord = _mapper.Map<SaveMarksRecordResource, MarksRecord>(resource);
            var result = await _marksRecordService.UpdateAsync(marksRecordId, marksRecord);

            if (!result.Success)
                return BadRequest(result.Message);

            var marksRecordResource = _mapper.Map<MarksRecord, MarksRecordResource>(result.Resource);
            return Ok(marksRecordResource);
        }
    }
}
