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
    public class UserSubjectService : IUserSubjectService
    {
        private readonly IUserSubjectRepository _userSubjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserSubjectService(IUserSubjectRepository userSubjectRepository, IUnitOfWork unitOfWork)
        {
            _userSubjectRepository = userSubjectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserSubjectResponse> AssignUserSubjectAsync(int userId, int subjectId)
        {
            try
            {
                await _userSubjectRepository.AssignUserSubject(userId, subjectId);
                await _unitOfWork.CompleteAsync();
                UserSubject userSubject = await _userSubjectRepository.FindByUserIdAndSubjectId(userId, subjectId);
                return new UserSubjectResponse(userSubject);
            }
            catch (Exception ex)
            {
                return new UserSubjectResponse($"An error ocurred while assigning User and Subject: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserSubject>> ListAsync()
        {
            return await _userSubjectRepository.ListAsync();
        }

        public async Task<IEnumerable<UserSubject>> ListBySubjectIdAsync(int subjectId)
        {
            return await _userSubjectRepository.ListBySubjectIdAsync(subjectId);
        }

        public async Task<IEnumerable<UserSubject>> ListByUserIdAsync(int userId)
        {
            return await _userSubjectRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserSubjectResponse> UnassignUserSubjectAsync(int userId, int subjectId)
        {
            try
            {
                UserSubject userSubject = await _userSubjectRepository.FindByUserIdAndSubjectId(userId, subjectId);
                _userSubjectRepository.Remove(userSubject);
                await _unitOfWork.CompleteAsync();
                return new UserSubjectResponse(userSubject);
            }
            catch(Exception ex)
            {
                return new UserSubjectResponse($"An error ocurred while unassign User to Subject: {ex.Message}");
            }
        }
    }
}
