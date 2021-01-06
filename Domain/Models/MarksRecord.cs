using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Models
{
    public class MarksRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GPA { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public Subject Subject { get; set; }
        public User User { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();

    }
}
