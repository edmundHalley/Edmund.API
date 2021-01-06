using Edmund.API.Domain.Models;

namespace Edmund.API.Domain.Services.Communications
{
    public class SubjectResponse : BaseResponse<Subject>
    {
        public SubjectResponse(Subject resource) : base(resource)
        {
        }
        public SubjectResponse(string message) : base(message)
        {
        }
    }
}
