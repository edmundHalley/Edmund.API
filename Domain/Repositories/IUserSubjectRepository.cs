using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IUserSubjectRepository
    {
        Task<IEnumerable<UserSubject>> ListAsync();
        Task<IEnumerable<UserSubject>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserSubject>> ListBySubjectIdAsync(int subjectId);
        Task<UserSubject> FindByUserIdAndSubjectId(int userId, int subjectId);
        Task AddAsync(UserSubject userSubject);
        void Remove(UserSubject userSubject);
        Task AssignUserSubject(int userId, int subjectId);
        void UnassignUserSubject(int userId, int subjectId);
    }
}
