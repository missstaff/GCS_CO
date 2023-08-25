using System;
using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime DateHired { get; set; }

        public Region Region { get; set; }
        public required string RegionAbbrev { get; set; }

        //public Skill Skill { get; set; }
        //public required string SkillName { get; set; }
        //public required int RateOfPay {  get; set; }


        public virtual ICollection<Address> Addresses { get; set; }
    }
}
