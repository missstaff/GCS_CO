using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rate of pay is required.")]
        public int RateOfPay { get; set; }
    }
}
