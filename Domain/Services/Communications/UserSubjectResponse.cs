using Edmund.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Services.Communications
{
    public class UserSubjectResponse : BaseResponse<UserSubject>
    {
        public UserSubjectResponse(UserSubject resource) : base(resource)
        {
        }
        public UserSubjectResponse(string message) : base(message)
        {
        }
    }
}
