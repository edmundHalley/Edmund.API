using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services.Communications
{
    public class ClassroomResponse : BaseResponse<Classroom>
    {
        public ClassroomResponse(Classroom resource) : base(resource)
        {
        }

        public ClassroomResponse(string message) : base(message)
        {
        }
    }
}
