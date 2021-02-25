using System.ComponentModel.DataAnnotations;

namespace Edmund.API.Domain.Services.Communications
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
