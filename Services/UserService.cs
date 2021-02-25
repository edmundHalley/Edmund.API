using Edmund.API.Domain.Models;
using Edmund.API.Domain.Repositories;
using Edmund.API.Domain.Services;
using Edmund.API.Domain.Services.Communications;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Edmund.API.Settings;

namespace Edmund.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            // TODO: Implement Repository-base behavior
            var user = await _userRepository.Authenticate(request.Username, request.Password);

            // Return when user not found
            if (user == null) return null;

            var token = GenerateJwtToken(user);

            return new AuthenticationResponse(user, token);
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            // Setup Security Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
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

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PhoneNumber = user.PhoneNumber;

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
