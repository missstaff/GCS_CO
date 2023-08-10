using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class State
    {
        [Key]
        public required string Abbreviation { get; set; }
        public required string Name { get; set; }

        public Region Region { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
