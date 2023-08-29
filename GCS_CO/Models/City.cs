using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public required string CityName { get; set; }

        public State? State { get; set; }
        public required string StateAbbrev { get; set; }
        public string? RegionAbbrev { get; set; }

        public PostalCode? PostalCode { get; set; }
        public required string Code { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}

