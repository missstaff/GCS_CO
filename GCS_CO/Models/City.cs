namespace GCS_CO.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the State
        public required State State { get; set; }
        public Region Region { get; set; }

    }
}

