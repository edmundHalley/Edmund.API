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
    public class EducationalStageSubjectService : IEducationalStageSubjectService
    {
        private readonly IEducationalStageSubjectRepository _educationalStageSubjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EducationalStageSubjectService(IEducationalStageSubjectRepository educationalStageSubjectRepository, IUnitOfWork unitOfWork)
        {
            _educationalStageSubjectRepository = educationalStageSubjectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<EducationalStageSubjectResponse> AssignEducationalStageSubjectAsync(int educationalStageId, int subjectId)
        {
            try
            {
                await _educationalStageSubjectRepository.AssignEducationalStageSubject(educationalStageId, subjectId);
                await _unitOfWork.CompleteAsync();
                EducationalStageSubject educationalStageSubject = await _educationalStageSubjectRepository.FindByEducationalStageIdAndSubjectId(educationalStageId, subjectId);
                return new EducationalStageSubjectResponse(educationalStageSubject);
            }
            catch (Exception ex)
            {
                return new EducationalStageSubjectResponse($"An error ocurred while assigning Educational Stage and Subject: {ex.Message}");
            }
        }

        public async Task<IEnumerable<EducationalStageSubject>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EducationalStageSubject>> ListByEducationalStageIdAsync(int educationalStageId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EducationalStageSubject>> ListBySubjectIdAsync(int subjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<EducationalStageSubjectResponse> UnassignEducationalStageSubjectAsync(int educationalStageId, int subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
