using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByHeadUserIdAsync(int userId);
        Task<IEnumerable<User>> ListEducationalStageUsersAsync(int educationalStageId);
        Task<IEnumerable<User>> ListClassroomUsersAsync(int classroomId);
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        Task<UserResponse> GetByIdAsync(int userId);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int userId, User user);
        Task<UserResponse> DeleteAsync(int userId);
    }
}
