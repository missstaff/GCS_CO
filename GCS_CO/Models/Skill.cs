using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int RateOfPay { get; set; }
    }
}
