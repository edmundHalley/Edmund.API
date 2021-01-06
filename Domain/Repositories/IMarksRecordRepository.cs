using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IMarksRecordRepository
    {
        Task<IEnumerable<MarksRecord>> ListAsync();
        Task<IEnumerable<MarksRecord>> ListSubjectMarksRecordsAsync(int subjectId);
        Task<IEnumerable<MarksRecord>> ListUserMarksRecordsAsync(int userId);
        Task<IEnumerable<MarksRecord>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId);
        Task AddAsync(MarksRecord marksRecord);
        Task<MarksRecord> GetSingleByIdAsync(int marksRecordId);
        void Update(MarksRecord marksRecord);
        void Remove(MarksRecord marksRecord);
    }
}
