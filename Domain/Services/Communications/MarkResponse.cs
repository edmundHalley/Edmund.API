using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services.Communications
{
    public class MarkResponse : BaseResponse<Mark>
    {
        public MarkResponse(Mark resource) : base(resource)
        {
        }

        public MarkResponse(string message) : base(message)
        {
        }
    }
}
