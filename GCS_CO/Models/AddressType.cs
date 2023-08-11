using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
