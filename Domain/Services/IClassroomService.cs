using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IClassroomService
    {
        Task<IEnumerable<Classroom>> ListAsync();
        Task<IEnumerable<Classroom>> ListEducationalStageClassroomsAsync(int educationalStageId);
        Task<ClassroomResponse> GetByIdAsync(int classroomId);
        Task<ClassroomResponse> SaveAsync(Classroom classroom);
        Task<ClassroomResponse> UpdateAsync(int classroomId, Classroom classroom);
        Task<ClassroomResponse> DeleteAsync(int classroomId);
    }
}
