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
    public class MarkRepository : BaseRepository, IMarkRepository
    {
        public MarkRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Mark mark)
        {
            await _context.Marks.AddAsync(mark);
        }
        public async Task<Mark> GetSingleByIdAsync(int markId)
        {
            return await _context.Marks.FindAsync(markId);
        }

        public async Task<IEnumerable<Mark>> ListAsync()
        {
            return await _context.Marks.ToListAsync();
        }

        public async Task<IEnumerable<Mark>> ListByClassroomIdAndSubjectIdAsync(int classroomId, int subjectId)
        {
            return await _context.Marks
                .OrderByDescending(a => a.Id)
                .Where(a => a.Subject.ClassroomId == classroomId && a.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> ListByUserIdAndMarksRecordIdAsync(int userId, int marksRecordId)
        {
            return await _context.Marks
                .OrderByDescending(a => a.User.Id)
                .Where(a => a.StudentId == userId && a.MarksRecordId == marksRecordId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId)
        {
            return await _context.Marks
                .OrderByDescending(a => a.User.Id)
                .Where(a => a.StudentId == userId && a.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> ListMarksRecordMarksAsync(int marksRecordId)
        {
            return await _context.Marks
                .Where(a => a.MarksRecordId == marksRecordId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> ListSubjectMarksAsync(int subjectId)
        {
            return await _context.Marks
                .Where(a => a.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> ListUserMarksAsync(int userId)
        {
            return await _context.Marks
                .Where(a => a.StudentId == userId)
                .ToListAsync();
        }

        public void Remove(Mark mark)
        {
            _context.Marks.Remove(mark);
        }

        public void Update(Mark mark)
        {
            _context.Marks.Update(mark);
        }
    }
}
