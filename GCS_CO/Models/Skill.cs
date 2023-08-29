using System.ComponentModel.DataAnnotations;


namespace GCS_CO.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public required string SkillName { get; set; }
        public required string SkillDescription { get; set; }
        public required int SkillPayRate { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<EmployeeSkill>? EmployeeSkills { get; set; }
    }
}
