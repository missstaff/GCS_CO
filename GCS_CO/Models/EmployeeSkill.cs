using System.ComponentModel.DataAnnotations;

namespace GCS_CO.Models

{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillId { get; set; }

        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Employee? Employee { get; set; }

        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; }
        public int? SkillPayRate { get; set; }
        public Skill? Skill { get; set; }
    }
}
