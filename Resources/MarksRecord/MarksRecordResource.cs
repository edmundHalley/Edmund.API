using Edmund.API.Resources.Subject;
using Edmund.API.Resources.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.MarksRecord
{
    public class MarksRecordResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GPA { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public SubjectResource Subject { get; set; }
        public UserResource User { get; set; }
    }
}
