using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models

{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillId { get; set; }

        public int EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Employee Employee { get; set; }

        public required string SkillName { get; set; }
        public required string SkillDescription { get; set; }
        public required int SkillPayRate { get; set; }
        public required Skill Skill { get; set; }
    }
}
