using Edmund.API.Domain.Models;

namespace Edmund.API.Domain.Services.Communications
{
    public class EducationalStageResponse : BaseResponse<EducationalStage>
    {
        public EducationalStageResponse(EducationalStage resource) : base(resource)
        {
        }

        public EducationalStageResponse(string message) : base(message)
        {
        }
    
    }
}
