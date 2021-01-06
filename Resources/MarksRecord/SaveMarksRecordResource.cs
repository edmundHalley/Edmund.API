using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.MarksRecord
{
    public class SaveMarksRecordResource
    {
        public string Name { get; set; }
        public decimal GPA { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
    }
}
