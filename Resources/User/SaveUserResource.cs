using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edmund.API.Resources.User
{
    public class SaveUserResource
    {
        public string Email { get; set; }
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
    }
}
