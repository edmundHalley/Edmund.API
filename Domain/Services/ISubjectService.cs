using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services.Communications
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> ListAsync();
        Task<IEnumerable<Subject>> ListSubjectClassroomsAsync(int classroomId);
        Task<SubjectResponse> GetByIdAsync(int subjectId);
        Task<SubjectResponse> SaveAsync(Subject subject);
        Task<SubjectResponse> UpdateAsync(int subjectId, Subject subject);
        Task<SubjectResponse> DeleteAsync(int subjectId);
    }
}
