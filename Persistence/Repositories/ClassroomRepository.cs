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
    public class ClassroomRepository : BaseRepository, IClassroomRepository
    {
        public ClassroomRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Classroom classroom)
        {
            await _context.Classrooms.AddAsync(classroom);
        }

        public async Task<Classroom> GetSingleByIdAsync(int classroomId)
        {
            return await _context.Classrooms.FindAsync(classroomId);
        }

        public async Task<IEnumerable<Classroom>> ListAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }
        public async Task<IEnumerable<Classroom>> ListEducationalStageClassroomsAsync(int educationalStageId)
        {
            return await _context.Classrooms
                .Where(a => a.EducationalStageId == educationalStageId)
                .ToListAsync();
        }


        public void Remove(Classroom classroom)
        {
            _context.Classrooms.Remove(classroom);
        }

        public void Update(Classroom classroom)
        {
            _context.Classrooms.Update(classroom);
        }
    }
}
