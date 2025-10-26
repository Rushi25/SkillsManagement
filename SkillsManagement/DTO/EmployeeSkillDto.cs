using System.ComponentModel.DataAnnotations;

namespace SkillsManagement.DTO
{
    public class EmployeeSkillDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required] 
        public int CustomerId { get; set; }

        [Required]
        public string SkillName { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int Rating { get; set; }
    }
}
