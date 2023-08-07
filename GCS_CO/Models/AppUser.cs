using Microsoft.AspNetCore.Identity;

namespace GCS_CO.Models
{
    public class AppUser : IdentityUser
    {
        public int IdNumber { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public byte? ProfilePicture { get; set; }
    }
}
