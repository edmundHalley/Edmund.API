using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IUserSubjectService
    {
    Task<IEnumerable<UserSubject>> ListAsync();
    Task<IEnumerable<UserSubject>> ListByUserIdAsync(int userId);
    Task<IEnumerable<UserSubject>> ListBySubjectIdAsync(int subjectId);
    Task<UserSubjectResponse> AssignUserSubjectAsync(int userId, int subjectId);
    Task<UserSubjectResponse> UnassignUserSubjectAsync(int userId, int subjectId);
}
}
