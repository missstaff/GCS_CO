using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public required string CityName { get; set; }

        public State State { get; set; }
        public required string? StateAbbrev { get; set; }
        public required string? RegionAbbrev { get; set; }

    }
}

