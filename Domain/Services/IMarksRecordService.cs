using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IMarksRecordService
    {
        Task<IEnumerable<MarksRecord>> ListAsync();
        Task<IEnumerable<MarksRecord>> ListByUserId(int userId);
        Task<IEnumerable<MarksRecord>> ListBySubjectId(int subjectId);
        Task<IEnumerable<MarksRecord>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId);
        Task<MarksRecordResponse> GetByIdAsync(int marksRecordId);
        Task<MarksRecordResponse> SaveAsync(MarksRecord marksRecord);
        Task<MarksRecordResponse> UpdateAsync(int marksRecordId, MarksRecord marksRecord);
        Task<MarksRecordResponse> DeleteAsync(int marksRecordId);
    }
}
