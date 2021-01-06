using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.Mark
{
    public class SaveMarkResource
    {
        public string Name { get; set; }
        public decimal Score { get; set; }
        public decimal Percentage { get; set; }
        public string Comment { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int MarksRecordId { get; set; }
    }
}
