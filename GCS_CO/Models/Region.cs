using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCS_CO.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public required string RegionAbbrev { get; set; }
        public required string RegionName { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
