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
        public required string RegionAbbrev { get; set; }

        //public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<PostalCode> PostalCodes { get; set; }
    }
}
