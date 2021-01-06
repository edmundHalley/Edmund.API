using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public int EducationalStageId { get; set; }
        public EducationalStage EducationalStage { get; set; }
    }
}
