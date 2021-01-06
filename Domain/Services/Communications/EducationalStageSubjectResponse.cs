using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services.Communications
{
    public class EducationalStageSubjectResponse : BaseResponse<EducationalStageSubject>
    {
        public EducationalStageSubjectResponse(EducationalStageSubject resource) : base(resource)
        {
        }
        public EducationalStageSubjectResponse(string message) : base(message)
        {
        }

    }
}
