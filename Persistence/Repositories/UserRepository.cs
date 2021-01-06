using Edmund.API.Domain.Models;
using Edmund.API.Domain.Persistence.Contexts;
using Edmund.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<IEnumerable<Mark>> CheckTeacher(int userId, bool type)
        {
            return (IEnumerable<Mark>)await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId && a.Type == type);
        }

        public async Task<User> GetSingleByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> ListClassroomUsersAsync(int classroomId)
        {
            return await _context.Users
                .Where(a => a.ClassroomId == classroomId)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> ListEducationalStageUsersAsync(int educationalStageId)
        {
            return await _context.Users
                .Where(a => a.EducationalStageId == educationalStageId)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> ListUsersByHeadUserAsync(int userId)
        {
            return await _context.Users
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
