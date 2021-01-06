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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserResponse> DeleteAsync(int subjectId)
        {
            var existingUser = await _userRepository.GetSingleByIdAsync(subjectId);
            if (existingUser == null)
                return new UserResponse("Subject not found");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting User: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int subjectId)
        {
            var existingUser = await _userRepository.GetSingleByIdAsync(subjectId);
            if (existingUser == null)
                return new UserResponse("Subject not found");
            return new UserResponse(existingUser);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<IEnumerable<User>> ListByHeadUserIdAsync(int userId)
        {
            return await _userRepository.ListUsersByHeadUserAsync(userId);
        }

        public async Task<IEnumerable<User>> ListClassroomUsersAsync(int classroomId)
        {
            return await _userRepository.ListClassroomUsersAsync(classroomId);
        }

        public async Task<IEnumerable<User>> ListEducationalStageUsersAsync(int educationalStageId)
        {
            return await _userRepository.ListEducationalStageUsersAsync(educationalStageId);
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving User: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int subjectId, User user)
        {
            var existingUser = await _userRepository.GetSingleByIdAsync(subjectId);
            if (existingUser == null)
                return new UserResponse("Subject not found");

            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Identification = user.Identification;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Birth = user.Birth;
            existingUser.Sex = user.Sex;
            existingUser.Address = user.Address;
            existingUser.Type = user.Type;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating User: {ex.Message}");
            }
        }
    }
}
