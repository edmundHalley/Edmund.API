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
    public class MarksRecordService : IMarksRecordService
    {
        private readonly IMarksRecordRepository _marksRecordRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarksRecordService(IMarksRecordRepository marksRecordRepository, IUnitOfWork unitOfWork)
        {
            _marksRecordRepository = marksRecordRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MarksRecordResponse> DeleteAsync(int marksRecordId)
        {
            var existingMarksRecord = await _marksRecordRepository.GetSingleByIdAsync(marksRecordId);

            if (existingMarksRecord == null)
                return new MarksRecordResponse("Marks Record not found");

            try
            {
                _marksRecordRepository.Remove(existingMarksRecord);
                await _unitOfWork.CompleteAsync();
                return new MarksRecordResponse(existingMarksRecord);
            }
            catch (Exception ex)
            {
                return new MarksRecordResponse($"An error ocurred while deleting Marks Record: {ex.Message}");
            }
        }

        public async Task<MarksRecordResponse> GetByIdAsync(int marksRecordId)
        {
            var existingMarksRecord = await _marksRecordRepository.GetSingleByIdAsync(marksRecordId);
            if (existingMarksRecord == null)
                return new MarksRecordResponse("Marks Record not found");
            return new MarksRecordResponse(existingMarksRecord);
        }

        public async Task<IEnumerable<MarksRecord>> ListAsync()
        {
            return await _marksRecordRepository.ListAsync();
        }

        public async Task<IEnumerable<MarksRecord>> ListBySubjectId(int subjectId)
        {
            return await _marksRecordRepository.ListSubjectMarksRecordsAsync(subjectId);
        }

        public async Task<IEnumerable<MarksRecord>> ListByUserId(int userId)
        {
            return await _marksRecordRepository.ListUserMarksRecordsAsync(userId);
        }

        public async Task<IEnumerable<MarksRecord>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId)
        {
            return await _marksRecordRepository.ListByUserIdAndSubjectIdAsync(userId, subjectId);
        }

        public async Task<MarksRecordResponse> SaveAsync(MarksRecord marksRecord)
        {
            try
            {
                await _marksRecordRepository.AddAsync(marksRecord);
                await _unitOfWork.CompleteAsync();
                return new MarksRecordResponse(marksRecord);
            }
            catch (Exception ex)
            {
                return new MarksRecordResponse($"An error ocurred while saving the Marks Record: {ex.Message}");
            }
        }

        public async Task<MarksRecordResponse> UpdateAsync(int marksRecordId, MarksRecord marksRecord)
        {
            var existingMarksRecord = await _marksRecordRepository.GetSingleByIdAsync(marksRecordId);

            if (existingMarksRecord == null)
                return new MarksRecordResponse("Marks Record not found");

            existingMarksRecord.Name = marksRecord.Name;
            existingMarksRecord.GPA = marksRecord.GPA;

            try
            {
                _marksRecordRepository.Update(existingMarksRecord);
                await _unitOfWork.CompleteAsync();
                return new MarksRecordResponse(existingMarksRecord);
            }
            catch (Exception ex)
            {
                return new MarksRecordResponse($"An error ocurred while updating Marks Record: {ex.Message}");
            }
        }
    }
}
