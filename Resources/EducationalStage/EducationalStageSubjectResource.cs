using Edmund.API.Resources.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.EducationalStage
{
    public class EducationalStageSubjectResource
    {
        public int EducationalStageId { get; set; }
        public int SubjectId { get; set; }
        public EducationalStageResource EducationalStage { get;set; }
        public SubjectResource Subject { get; set; }


    }
}
