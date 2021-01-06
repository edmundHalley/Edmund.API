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
    public class SubjectRepository : BaseRepository, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
        }

        public async Task<Subject> GetSingleByIdAsync(int subjectId)
        {
            return await _context.Subjects.FindAsync(subjectId);
        }

        public async Task<IEnumerable<Subject>> ListAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<IEnumerable<Subject>> ListSubjectClassroomsAsync(int classroomId)
        {
            return await _context.Subjects
                .Where(a => a.ClassroomId == classroomId)
                .ToListAsync();
        }

        public void Remove(Subject subject)
        {
            _context.Subjects.Remove(subject);
        }

        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }
    }
}
