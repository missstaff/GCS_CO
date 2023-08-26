using System;
using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime DateHired { get; set; }

        public Region? Region { get; set; }
        public required string RegionAbbrev { get; set; }

        public virtual required ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EmployeeSkill>? EmployeeSkills { get; set; }
    }
}
