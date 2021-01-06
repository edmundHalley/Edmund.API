using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IMarkService
    {
        Task<IEnumerable<Mark>> ListAsync();
        Task<IEnumerable<Mark>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId);
        Task<IEnumerable<Mark>> ListBySubjectId(int subjectId);
        Task<IEnumerable<Mark>> ListByUserIdAndMarksRecordIdAsync(int userId, int marksRecordId);
        Task<IEnumerable<Mark>> ListByClassroomIdAndSubjectIdAsync(int classroomId, int subjectId);
        Task<MarkResponse> GetByIdAsync(int markId);
        Task<MarkResponse> SaveAsync(int teacherId, int subjectId, int userId, Mark mark);
        Task<MarkResponse> UpdateAsync(int teacherId, int subjectId, int userId, int markId, Mark mark);
        Task<MarkResponse> DeleteAsync(int teacherId, int subjectId, int userId, int markId);
    }
}
