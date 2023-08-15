using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class PostalCode
    {
        [Key]
        public int PostalCodeId { get; set; }
        public required string Code { get; set; }

        public  City City { get; set; }
        public string? CityName { get; set; }
        public string? StateAbbrev { get; set; }

    }
}