using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public List<MarksRecord> MarksRecords { get; set; } = new List<MarksRecord>();
        public List<UserSubject> UserSubjects { get; set; } = new List<UserSubject>();
        public List<EducationalStageSubject> EducationalStageSubjects { get; set; } = new List<EducationalStageSubject>();        
    }
}
