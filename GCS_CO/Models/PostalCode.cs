using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class PostalCode
    {
        [Key]
        public int Id { get; set; }
        public required string Code { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}