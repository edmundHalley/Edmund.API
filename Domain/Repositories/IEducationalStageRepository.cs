using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Repositories
{
    public interface IEducationalStageRepository
    {
        Task<IEnumerable<EducationalStage>> ListAsync();
        Task<EducationalStage> GetSingleByIdAsync(int educationalStageId);
        Task AddAsync(EducationalStage educationalStage);
        void Update(EducationalStage educationalStage);
        void Remove(EducationalStage educationalStage);
    }
}
