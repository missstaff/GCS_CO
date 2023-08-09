using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
