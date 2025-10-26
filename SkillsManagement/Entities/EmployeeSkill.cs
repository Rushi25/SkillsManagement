using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsManagement.Entities
{
    public class EmployeeSkill
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string SkillName { get; set; }
        public int Rating { get; set; }
    }
}
