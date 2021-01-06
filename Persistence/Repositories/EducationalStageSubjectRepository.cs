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
    public class EducationalStageSubjectRepository : BaseRepository, IEducationalStageSubjectRepository
    {
        public EducationalStageSubjectRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(EducationalStageSubject educationalStageSubject)
        {
            await _context.EducationalStageSubjects.AddAsync(educationalStageSubject);
        }

        public async Task AssignEducationalStageSubject(int educationalStageId, int subjectId)
        {
            EducationalStageSubject educationalStageSubject = await FindByEducationalStageIdAndSubjectId(educationalStageId, subjectId);

            if (educationalStageSubject == null)
            {
                educationalStageSubject = new EducationalStageSubject
                {
                    EducationalStageId = educationalStageId,
                    SubjectId = subjectId
                };
                await AddAsync(educationalStageSubject);
            }
        }

        public async Task<EducationalStageSubject> FindByEducationalStageIdAndSubjectId(int educationalStageId, int subjectId)
        {
            return await _context.EducationalStageSubjects.FindAsync(educationalStageId, subjectId);
        }

        public async Task<IEnumerable<EducationalStageSubject>> ListAsync()
        {
            return await _context.EducationalStageSubjects
                .Include(a => a.EducationalStage)
                .Include(a => a.Subject)
                .ToListAsync();
        }

        public async Task<IEnumerable<EducationalStageSubject>> ListByEducationalStageIdAsync(int educationalStageId)
        {
            return await _context.EducationalStageSubjects
                .Where(a => a.EducationalStageId == educationalStageId)
                .Include(a => a.EducationalStage)
                .Include(a => a.Subject)
                .ToListAsync();
        }

        public async Task<IEnumerable<EducationalStageSubject>> ListBySubjectIdAsync(int subjectId)
        {
            return await _context.EducationalStageSubjects
                .Where(a => a.SubjectId == subjectId)
                .Include(a => a.EducationalStage)
                .Include(a => a.Subject)
                .ToListAsync();
        }

        public void Remove(EducationalStageSubject educationalStageSubject)
        {
            _context.EducationalStageSubjects.Remove(educationalStageSubject);
        }

        public async void UnassignEducationalStageSubject(int educationalStageId, int subjectId)
        {
            EducationalStageSubject educationalStageSubject = await FindByEducationalStageIdAndSubjectId(educationalStageId, subjectId);
            if (educationalStageSubject != null)
            {
                Remove(educationalStageSubject);
            }
        }
    }
}
