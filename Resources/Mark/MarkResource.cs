using Edmund.API.Resources.MarksRecord;
using Edmund.API.Resources.Subject;
using Edmund.API.Resources.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.Mark
{
    public class MarkResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Score { get; set; }
        public decimal Percentage { get; set; }
        public string Comment { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int MarksRecordId { get; set; }
        public UserResource User { get; set; }
        public SubjectResource Subject { get; set; }
        public MarksRecordResource MarksRecord { get; set; }
    }
}
