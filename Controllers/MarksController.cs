using AutoMapper;
using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services;
using Edmund.API.Extensions;
using Edmund.API.Resources.Mark;
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
    public class MarksController : ControllerBase
    {
        private readonly IMarkService _markService;
        private readonly IMapper _mapper;

        public MarksController(IMarkService markService, IMapper mapper)
        {
            _markService = markService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List of All Marks",
            Description = "List of All Marks")]
        [SwaggerResponse(200, "List of Marks", typeof(MarkResource))]
        [HttpGet]
        public async Task<IEnumerable<MarkResource>> GetAllAsync()
        {
            var marks = await _markService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Mark>, IEnumerable<MarkResource>>(marks);
            return resources;
        }



        [SwaggerOperation(
            Summary = "Details of a Mark",
            Description = "Details of a Mark")]
        [SwaggerResponse(200, "Details of a Mark", typeof(MarkResource))]
        [HttpGet("{markId}")]
        public async Task<IActionResult> GetByIdAsync(int markId)
        {
            var result = await _markService.GetByIdAsync(markId);

            if (!result.Success)
                return BadRequest(result.Message);
            var markResource = _mapper.Map<Mark, MarkResource>(result.Resource);
            return Ok(markResource);
        }

        
        
        
        
    }
}
