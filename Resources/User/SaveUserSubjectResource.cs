using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.User
{
    public class SaveUserSubjectResource
    {
        public int UserId { get; set; }
        public int SubjectId { get; set; }
    }
}
