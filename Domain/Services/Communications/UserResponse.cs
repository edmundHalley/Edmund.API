using Edmund.API.Domain.Models;

namespace Edmund.API.Domain.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource)
        {
        }
        public UserResponse(string message) : base(message)
        {
        }
    }
}
