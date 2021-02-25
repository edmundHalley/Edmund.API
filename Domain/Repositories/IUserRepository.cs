using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListEducationalStageUsersAsync(int educationalStageId);
        Task<IEnumerable<User>> ListClassroomUsersAsync(int classroomId);
        Task<IEnumerable<User>> ListUsersByHeadUserAsync(int userId);
        Task<User> GetSingleByIdAsync(int userId);
        Task<IEnumerable<Mark>> CheckTeacher(int userId, bool type);
        Task<User> Authenticate(string username, string password);
        Task AddAsync(User user);
        void Remove(User user);
        void Update(User user);


    }
}
