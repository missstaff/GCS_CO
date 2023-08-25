using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public required string RegionAbbrev { get; set; }
        public required string RegionName { get; set; }

        public virtual ICollection<State> States { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
