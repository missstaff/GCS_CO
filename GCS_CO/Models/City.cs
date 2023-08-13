using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public required string CityName { get; set; }
        public required State CityState { get; set; }
        public required Region CityRegion { get; set; }

    }
}

