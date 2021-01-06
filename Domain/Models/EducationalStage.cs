using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Models
{
    public class EducationalStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Classroom> Classrooms { get; set; } = new List<Classroom>();
        public List<User> Users { get; set; } = new List<User>();
        public List<EducationalStageSubject> EducationalStageSubjects { get; set; } = new List<EducationalStageSubject>();
    }
}
