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
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarkService(IMarkRepository markRepository, IUserRepository userRepository, ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            _markRepository = markRepository;
            _subjectRepository = subjectRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MarkResponse> DeleteAsync(int teacherId, int subjectId, int userId, int markId)
        {
            var existingTeacher = await _userRepository.GetSingleByIdAsync(teacherId);
            var existingSubject = await _subjectRepository.GetSingleByIdAsync(subjectId);
            var existingStudent = await _userRepository.GetSingleByIdAsync(userId);
            var existingMark = await _markRepository.GetSingleByIdAsync(markId);

            if (existingTeacher.Type == false)
                return new MarkResponse("You can't delete this mark");
            if (existingSubject == null)
                return new MarkResponse("Subject not found");
            if (existingStudent == null)
                return new MarkResponse("Student not found");
            if (existingMark == null)
                return new MarkResponse("Mark not found");

            try
            {
                _markRepository.Remove(existingMark);
                await _unitOfWork.CompleteAsync();
                return new MarkResponse(existingMark);
            }
            catch (Exception ex)
            {
                return new MarkResponse($"An error ocurred while deleting mark: {ex.Message}");
            }
        }

        public async Task<MarkResponse> GetByIdAsync(int markId)
        {
            var existingMark = await _markRepository.GetSingleByIdAsync(markId);
            if (existingMark == null)
                return new MarkResponse("Mark not found");
            return new MarkResponse(existingMark);
        }

        public async Task<IEnumerable<Mark>> ListAsync()
        {
            return await _markRepository.ListAsync();
        }

        public async Task<IEnumerable<Mark>> ListByClassroomIdAndSubjectIdAsync(int classroomId, int subjectId)
        {
            return await _markRepository.ListByClassroomIdAndSubjectIdAsync(classroomId, subjectId);
        }

        public async Task<IEnumerable<Mark>> ListBySubjectId(int subjectId)
        {
            return await _markRepository.ListSubjectMarksAsync(subjectId);
        }

        public async Task<IEnumerable<Mark>> ListByUserIdAndMarksRecordIdAsync(int userId, int marksRecordId)
        {
            return await _markRepository.ListByUserIdAndMarksRecordIdAsync(userId, marksRecordId);
        }

        public async Task<IEnumerable<Mark>> ListByUserIdAndSubjectIdAsync(int userId, int subjectId)
        {
            return await _markRepository.ListByUserIdAndSubjectIdAsync(userId, subjectId);
        }

        public async Task<MarkResponse> SaveAsync(int teacherId, int subjectId, int userId, Mark mark)
        {
            var existingTeacher = await _userRepository.GetSingleByIdAsync(teacherId);
            var existingSubject = await _subjectRepository.GetSingleByIdAsync(subjectId);
            var existingStudent = await _userRepository.GetSingleByIdAsync(userId);

            if (existingTeacher.Type == false)
                return new MarkResponse("You can't save this mark");
            if (existingSubject == null)
                return new MarkResponse("Subject not found");
            if (existingStudent == null)
                return new MarkResponse("Student not found");

            try
            {
                await _markRepository.AddAsync(mark);
                await _unitOfWork.CompleteAsync();
                return new MarkResponse(mark);
            }
            catch (Exception ex)
            {
                return new MarkResponse(
                    $"An error ocurred while saving the Mark: {ex.Message}");
            }
        }

        public async Task<MarkResponse> UpdateAsync(int teacherId, int subjectId, int userId, int markId, Mark mark)
        {
            var existingTeacher = await _userRepository.GetSingleByIdAsync(teacherId);
            var existingSubject = await _subjectRepository.GetSingleByIdAsync(subjectId);
            var existingStudent = await _userRepository.GetSingleByIdAsync(userId);
            var existingMark = await _markRepository.GetSingleByIdAsync(markId);

            if (existingTeacher.Type == false)
                return new MarkResponse("You can't update this mark");
            if (existingSubject == null)
                return new MarkResponse("Subject not found");
            if (existingStudent == null)
                return new MarkResponse("Student not found");
            if (existingMark == null)
                return new MarkResponse("Mark not found");


            existingMark.Name = mark.Name;
            existingMark.Percentage = mark.Percentage;
            existingMark.Score = mark.Score;
            existingMark.Comment = mark.Comment;

            try
            {
                _markRepository.Update(existingMark);
                await _unitOfWork.CompleteAsync();
                return new MarkResponse(existingMark);
            }
            catch (Exception ex)
            {
                return new MarkResponse($"An error ocurred while updating the Mark: {ex.Message}");
            }
            
        }
    }
}
