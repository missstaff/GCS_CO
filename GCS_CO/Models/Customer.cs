using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        // Foreign key to Address table
        [Required(ErrorMessage = "Address is required.")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        // Foreign key to Region table
        //[Required(ErrorMessage = "Region is required.")]
        //public int RegionId { get; set; }
        //public Region? Region { get; set; }
    }
}
