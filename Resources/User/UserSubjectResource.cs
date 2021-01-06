using Edmund.API.Resources.Subject;
using Edmund.API.Resources.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.User
{
    public class UserSubjectResource
    {
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public UserResource User { get; set; }
        public SubjectResource Subject { get; set; }
    }
}
