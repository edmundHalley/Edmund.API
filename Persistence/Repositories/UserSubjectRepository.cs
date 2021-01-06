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
    public class UserSubjectRepository : BaseRepository, IUserSubjectRepository
    {
        public UserSubjectRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(UserSubject userSubject)
        {
            await _context.UserSubjects.AddAsync(userSubject);
        }

        public async Task AssignUserSubject(int userId, int subjectId)
        {
            UserSubject userSubject = await FindByUserIdAndSubjectId(userId, subjectId);

            if (userSubject == null)
            {
                userSubject = new UserSubject
                {
                    UserId = userId,
                    SubjectId = subjectId
                };
                await AddAsync(userSubject);
            }
        }

        public async Task<UserSubject> FindByUserIdAndSubjectId(int userId, int subjectId)
        {
            return await _context.UserSubjects.FindAsync(userId, subjectId);
        }

        public async Task<IEnumerable<UserSubject>> ListAsync()
        {
            return await _context.UserSubjects
                .Include(a => a.User)
                .Include(a => a.Subject)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSubject>> ListBySubjectIdAsync(int subjectId)
        {
            return await _context.UserSubjects
                .Where(a => a.SubjectId == subjectId)
                .Include(a => a.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSubject>> ListByUserIdAsync(int userId)
        {
            return await _context.UserSubjects
                .Where(a => a.UserId == userId)
                .Include(a => a.Subject)
                .ToListAsync();
        }

        public void Remove(UserSubject userSubject)
        {
            _context.UserSubjects.Remove(userSubject);
        }

        public async void UnassignUserSubject(int userId, int subjectId)
        {
            UserSubject userSubject = await FindByUserIdAndSubjectId(userId, subjectId);
            
            if(userSubject != null)
            {
                Remove(userSubject);
            }
        }

    }
}
