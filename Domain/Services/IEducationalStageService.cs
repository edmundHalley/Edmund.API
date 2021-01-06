using Edmund.API.Domain.Models;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services
{
    public interface IEducationalStageService
    {
        Task<IEnumerable<EducationalStage>> ListAsync();
        Task<EducationalStageResponse> GetByIdAsync(int educationalStageId);
        Task<EducationalStageResponse> SaveAsync(EducationalStage educationalStage);
        Task<EducationalStageResponse> UpdateAsync(int educationalStageId, EducationalStage educationalStage);
        Task<EducationalStageResponse> DeleteAsync(int educationalStageId);

    }
}
