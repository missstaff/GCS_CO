using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Region
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A region abbreviation is required.")]
        public string Abbreviation { get; set; }
    }
}
