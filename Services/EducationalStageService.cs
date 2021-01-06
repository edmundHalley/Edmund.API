using Edmund.API.Domain.Models;
using Edmund.API.Domain.Repositories;
using Edmund.API.Domain.Services;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Services
{
    public class EducationalStageService : IEducationalStageService
    {
        private readonly IEducationalStageRepository _educationalStageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EducationalStageService(IEducationalStageRepository educationalStageRepository, IUnitOfWork unitOfWork)
        {
            _educationalStageRepository = educationalStageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EducationalStageResponse> DeleteAsync(int educationalStageId)
        {
            var existingEducationalStage= await _educationalStageRepository.GetSingleByIdAsync(educationalStageId);

            if (existingEducationalStage == null)
                return new EducationalStageResponse("Educational Stage not found");

            try
            {
                _educationalStageRepository.Remove(existingEducationalStage);
                await _unitOfWork.CompleteAsync();

                return new EducationalStageResponse(existingEducationalStage);
            }
            catch (Exception ex)
            {
                return new EducationalStageResponse($"An error ocurred while deleting Educational Stage: {ex.Message}");
            }
        }

        public async Task<EducationalStageResponse> GetByIdAsync(int educationalStageId)
        {
            var existingEducationalStage = await _educationalStageRepository.GetSingleByIdAsync(educationalStageId);
            if (existingEducationalStage == null)
                return new EducationalStageResponse("Educational Stage not found");
            return new EducationalStageResponse(existingEducationalStage);
        }

        public async Task<IEnumerable<EducationalStage>> ListAsync()
        {
            return await _educationalStageRepository.ListAsync();
        }

        public async Task<EducationalStageResponse> SaveAsync(EducationalStage educationalStage)
        {
            try
            {
                await _educationalStageRepository.AddAsync(educationalStage);
                await _unitOfWork.CompleteAsync();

                return new EducationalStageResponse(educationalStage);
            }
            catch (Exception ex)
            {
                return new EducationalStageResponse(
                    $"An error ocurred while saving the Educational Stage: {ex.Message}");
            }
        }

        public async Task<EducationalStageResponse> UpdateAsync(int educationalStageId, EducationalStage educationalStage)
        {
            var existingEducationalStage = await _educationalStageRepository.GetSingleByIdAsync(educationalStageId);

            if (existingEducationalStage == null)
                return new EducationalStageResponse("Educational Stage not found");

            existingEducationalStage.Name = educationalStage.Name;

            try
            {
                _educationalStageRepository.Update(existingEducationalStage);
                await _unitOfWork.CompleteAsync();

                return new EducationalStageResponse(existingEducationalStage);
            }
            catch (Exception ex)
            {
                return new EducationalStageResponse($"An error ocurred while updating the Educational Stage: {ex.Message}");
            }
        }
    }
}
