using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Edmund.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birth { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
        public bool Type { get; set; }
        public int UserId { get; set; }
        public int EducationalStageId { get; set; }
        public EducationalStage EducationalStage { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public List<UserSubject> UserSubjects { get; set; } = new List<UserSubject>();
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public List<MarksRecord> MarksRecords { get; set; } = new List<MarksRecord>();
        public List<User> Users { get; set; } = new List<User>();

        [JsonIgnore]
        public string Token { get; set; }

    }
}
