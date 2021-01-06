using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> ListAsync();
        Task<IEnumerable<Mark>> ListUserMarksAsync(int userId);
        Task<IEnumerable<Mark>> ListSubjectMarksAsync(int subjectId);
        Task<IEnumerable<Mark>> ListMarksRecordMarksAsync(int marksRecordId);
        Task<IEnumerable<Mark>> ListByUserIdAndMarksRecordIdAsync(int userId, int marksRecordId);
        Task<IEnumerable<Mark>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId);
        Task<IEnumerable<Mark>> ListByClassroomIdAndSubjectIdAsync(int classroomId, int subjectId);

        Task AddAsync(Mark mark);
        Task<Mark> GetSingleByIdAsync(int markId);

        void Update(Mark mark);
        void Remove(Mark mark);
    }
}
