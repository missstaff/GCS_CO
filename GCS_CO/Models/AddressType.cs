using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }
        public required string Type { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
