using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode { get; set; }
    }
}
