using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Domain.Models
{
    public class UserSubject
    {
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public User User { get; set; }
        public Subject Subject { get; set; }

    }
}
