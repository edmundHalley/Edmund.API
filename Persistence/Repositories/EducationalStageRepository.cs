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
    public class EducationalStageRepository : BaseRepository, IEducationalStageRepository
    {
        public EducationalStageRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(EducationalStage educationalStage)
        {
            await _context.EducationalStages.AddAsync(educationalStage);
        }

        public async Task<EducationalStage> GetSingleByIdAsync(int educationalStageId)
        {
            return await _context.EducationalStages.FindAsync(educationalStageId);
        }

        public async Task<IEnumerable<EducationalStage>> ListAsync()
        {
            return await _context.EducationalStages.ToListAsync();
        }

        public void Remove(EducationalStage educationalStage)
        {
            _context.EducationalStages.Remove(educationalStage);
        }

        public void Update(EducationalStage educationalStage)
        {
            _context.EducationalStages.Update(educationalStage);
        }
    }
}
