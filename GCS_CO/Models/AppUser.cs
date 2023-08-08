using Microsoft.AspNetCore.Identity;

namespace GCS_CO.Models
{
    public class AppUser : IdentityUser
    {
        public int IdNumber { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        private string _email;
        public override string Email
        {
            get => _email;
            set
            {
                _email = value;
                NormalizedEmail = value?.ToUpper();
            }
        }

        public override string NormalizedEmail { get; set; }

        public byte? ProfilePicture { get; set; }
    }
}
