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
    public class MarksRecordRepository : BaseRepository, IMarksRecordRepository
    {
        public MarksRecordRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(MarksRecord marksRecord)
        {
            await _context.MarksRecords.AddAsync(marksRecord);
        }

        public async Task<MarksRecord> GetSingleByIdAsync(int marksRecordId)
        {
            return await _context.MarksRecords.FindAsync(marksRecordId);
        }

        public async Task<IEnumerable<MarksRecord>> ListAsync()
        {
            return await _context.MarksRecords.ToListAsync();
        }

        public async Task<IEnumerable<MarksRecord>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId)
        {
            return await _context.MarksRecords
                .Where(a => a.UserId == userId && a.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MarksRecord>> ListSubjectMarksRecordsAsync(int subjectId)
        {
            return await _context.MarksRecords
                .Where(a => a.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MarksRecord>> ListUserMarksRecordsAsync(int userId)
        {
            return await _context.MarksRecords
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public void Remove(MarksRecord marksRecord)
        {
            _context.MarksRecords.Remove(marksRecord);
        }

        public void Update(MarksRecord marksRecord)
        {
            _context.MarksRecords.Update(marksRecord);
        }
    }
}
