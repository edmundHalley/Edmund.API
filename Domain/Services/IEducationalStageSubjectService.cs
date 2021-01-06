using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IEducationalStageSubjectService
    {
        Task<IEnumerable<EducationalStageSubject>> ListAsync();
        Task<IEnumerable<EducationalStageSubject>> ListByEducationalStageIdAsync(int educationalStageId);
        Task<IEnumerable<EducationalStageSubject>> ListBySubjectIdAsync(int subjectId);
        Task<EducationalStageSubjectResponse> AssignEducationalStageSubjectAsync(int educationalStageId, int subjectId);
        Task<EducationalStageSubjectResponse> UnassignEducationalStageSubjectAsync(int educationalStageId, int subjectId);
    }
}
