using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> ListAsync();
        Task<IEnumerable<Subject>> ListSubjectClassroomsAsync(int classroomId);
        Task AddAsync(Subject subject);
        Task<Subject> GetSingleByIdAsync(int subjectId);
        void Update(Subject subject);
        void Remove(Subject subject);
    }
}
