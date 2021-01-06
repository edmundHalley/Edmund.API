using System;
using Edmund.API.Domain.Models;

namespace Edmund.API.Domain.Services.Communications
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birth { get; set; }
        public Boolean Sex { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Identification = user.Identification;
            PhoneNumber = user.PhoneNumber;
            Birth = user.Birth;
            Sex = user.Sex;
            Address = user.Address;
            Token = token;
        }
    }
}
