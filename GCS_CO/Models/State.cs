using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public required string StateAbbrev { get; set; }
        public required string StateName { get; set; }
        public Region Region { get; set; }
        public string? RegionAbbrev { get; set; } 
        public ICollection<City> Cities { get; set; }

    }
}
