using Edmund.API.Domain.Models;

namespace Edmund.API.Domain.Services.Communications
{
    public class MarksRecordResponse : BaseResponse<MarksRecord>
    {
        public MarksRecordResponse(MarksRecord resource) : base(resource)
        {
        }

        public MarksRecordResponse(string message) : base(message)
        {
        }
    }
}
