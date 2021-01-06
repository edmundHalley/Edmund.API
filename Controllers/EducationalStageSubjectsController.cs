using AutoMapper;
using Edmund.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Controllers
{
    public class EducationalStageSubjectsController : ControllerBase
    {
        private readonly IEducationalStageSubjectService _educationStageSubjectService;
        private readonly IMapper _mapper;

        public EducationalStageSubjectsController(IEducationalStageSubjectService educationalStageSubjectService, IMapper mapper)
        {
            _educationStageSubjectService = educationalStageSubjectService;
            _mapper = mapper;
        }

    }
}
