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
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomService(IClassroomRepository classroomRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _classroomRepository = classroomRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ClassroomResponse> DeleteAsync(int classroomId)
        {
            var existingClassroom = await _classroomRepository.GetSingleByIdAsync(classroomId);

            if (existingClassroom == null)
                return new ClassroomResponse("Educational Stage not found");

            try
            {
                _classroomRepository.Remove(existingClassroom);
                await _unitOfWork.CompleteAsync();

                return new ClassroomResponse(existingClassroom);
            }
            catch (Exception ex)
            {
                return new ClassroomResponse($"An error ocurred while deleting Classroom: {ex.Message}");
            }
        }

        public async Task<ClassroomResponse> GetByIdAsync(int classroomId)
        {
            var existingClassroom = await _classroomRepository.GetSingleByIdAsync(classroomId);
            if (existingClassroom == null)
                return new ClassroomResponse("Classroom not found");
            return new ClassroomResponse(existingClassroom);
        }

        public async Task<IEnumerable<Classroom>> ListAsync()
        {
            return await _classroomRepository.ListAsync();
        }

        public async Task<IEnumerable<Classroom>> ListEducationalStageClassroomsAsync(int educationalStageId)
        {
            return await _classroomRepository.ListEducationalStageClassroomsAsync(educationalStageId);
        }

        public async Task<ClassroomResponse> SaveAsync(Classroom classroom)
        {
            try
            {
                await _classroomRepository.AddAsync(classroom);
                await _unitOfWork.CompleteAsync();

                return new ClassroomResponse(classroom);
            }
            catch (Exception ex)
            {
                return new ClassroomResponse(
                    $"An error ocurred while saving the Classroom: {ex.Message}");
            }
        }

        public async Task<ClassroomResponse> UpdateAsync(int classroomId, Classroom classroom)
        {
            var existingClassroom = await _classroomRepository.GetSingleByIdAsync(classroomId);

            if (existingClassroom == null)
                return new ClassroomResponse("Educational Stage not found");

            existingClassroom.Name = classroom.Name;

            try
            {
                _classroomRepository.Update(existingClassroom);
                await _unitOfWork.CompleteAsync();

                return new ClassroomResponse(existingClassroom);
            }
            catch (Exception ex)
            {
                return new ClassroomResponse($"An error ocurred while updating the Classroom: {ex.Message}");
            }
        }
    }
}
