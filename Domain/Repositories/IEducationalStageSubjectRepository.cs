using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IEducationalStageSubjectRepository
    {
        Task<IEnumerable<EducationalStageSubject>> ListAsync();
        Task<IEnumerable<EducationalStageSubject>> ListByEducationalStageIdAsync(int educationalStageId);
        Task<IEnumerable<EducationalStageSubject>> ListBySubjectIdAsync(int subjectId);
        Task<EducationalStageSubject> FindByEducationalStageIdAndSubjectId(int educationalStageId, int subjectId);
        Task AddAsync(EducationalStageSubject educationalStageSubject);
        void Remove(EducationalStageSubject educationalStageSubject);
        Task AssignEducationalStageSubject(int educationalStageId, int subjectId);
        void UnassignEducationalStageSubject(int educationalStageId, int subjectId);
    }
}
