using Edmund.API.Domain.Models;
using Edmund.API.Domain.Repositories;
using Edmund.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public SubjectService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<SubjectResponse> DeleteAsync(int subjectId)
        {
            var existingSubject = await _subjectRepository.GetSingleByIdAsync(subjectId);

            if (existingSubject == null)
                return new SubjectResponse("Subject not found");

            try
            {
                _subjectRepository.Remove(existingSubject);
                await _unitOfWork.CompleteAsync();
                return new SubjectResponse(existingSubject);
            }
            catch (Exception ex)
            {
                return new SubjectResponse($"An error ocurred while deleting Subject: {ex.Message}");
            }
        }

        public async Task<SubjectResponse> GetByIdAsync(int subjectId)
        {
            var existingSubject = await _subjectRepository.GetSingleByIdAsync(subjectId);
            if (existingSubject == null)
                return new SubjectResponse("Subject not found");
            return new SubjectResponse(existingSubject);
        }

        public async Task<IEnumerable<Subject>> ListAsync()
        {
            return await _subjectRepository.ListAsync();
        }

        public async Task<IEnumerable<Subject>> ListSubjectClassroomsAsync(int classroomId)
        {
            return await _subjectRepository.ListSubjectClassroomsAsync(classroomId);
        }

        public async Task<SubjectResponse> SaveAsync(Subject subject)
        {
            try
            {
                await _subjectRepository.AddAsync(subject);
                await _unitOfWork.CompleteAsync();
                return new SubjectResponse(subject);
            }
            catch (Exception ex)
            {
                return new SubjectResponse($"An error ocurred while saving Subject: {ex.Message}");
            }
        }

        public async Task<SubjectResponse> UpdateAsync(int subjectId, Subject subject)
        {
            var existingSubject = await _subjectRepository.GetSingleByIdAsync(subjectId);

            if (existingSubject == null)
                return new SubjectResponse("Subject not found");

            existingSubject.Name = subject.Name;
            
            try
            {
                _subjectRepository.Update(existingSubject);
                await _unitOfWork.CompleteAsync();
                return new SubjectResponse(existingSubject);
            }
            catch (Exception ex)
            {
                return new SubjectResponse($"An error ocurred while updating Subject: {ex.Message}");
            }
        }
    }
}
