using System;
using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date hired is required.")]
        public DateTime DateHired { get; set; }

        //// Foreign key to Region table
        //[Required(ErrorMessage = "Region is required.")]
        //public int RegionId { get; set; }
        //public Region Region { get; set; }

        // Foreign key to Skill table
        [Required(ErrorMessage = "Skill is required.")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        // Foreign key to Address table
        [Required(ErrorMessage = "Address is required.")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
