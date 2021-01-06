using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<Classroom>> ListAsync();
        Task<IEnumerable<Classroom>> ListEducationalStageClassroomsAsync(int educationalStageId);
        Task<Classroom> GetSingleByIdAsync(int classroomId);
        Task AddAsync(Classroom classroom);
        void Update(Classroom classroom);
        void Remove(Classroom classroom);
    }
}
