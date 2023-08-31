using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
        public required string Street { get; set; }

        public City? City { get; set; }
        public string? CityName { get; set; }
        public string? StateAbbrev { get; set; }
        public string? PostalCode { get; set; }
        public string? RegionAbbrev { get; set; }

        public AddressType? AddressType { get; set; }
        public required string Type { get; set; }
    }
}
