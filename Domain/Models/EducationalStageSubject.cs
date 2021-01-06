using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Models
{
    public class EducationalStageSubject
    {
        public int EducationalStageId { get; set; }
        public int SubjectId { get; set; }
        public EducationalStage EducationalStage { get; set; }
        public Subject Subject { get; set; }
    }
}
