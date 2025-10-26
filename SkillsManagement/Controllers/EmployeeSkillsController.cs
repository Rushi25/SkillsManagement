using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillsManagement.DTO;
using SkillsManagement.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SkillsManagement.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "User")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly SkillsDbContext _dbContext;

        public EmployeeSkillsController(SkillsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeSkillDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([Required]int employeeId, [Required]int customerId)
        {
            var skills = await _dbContext.EmployeeSkills
                .Where(es => es.EmployeeId == employeeId && es.CustomerId == customerId)
                .Select(a => new EmployeeSkillDto
                {
                    EmployeeId = a.EmployeeId,
                    SkillName = a.SkillName,
                    Rating = a.Rating
                })
                .ToListAsync();

            return Ok(skills);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(EmployeeSkill), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddSkill([FromBody] EmployeeSkillDto employeeSkill)
        {
            // Validate that the employee exists
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeSkill.EmployeeId && e.CustomerId == employeeSkill.CustomerId);
            if (employee == null)
            {
                return NotFound($"Employee with ID {employeeSkill.EmployeeId} not found.");
            }

            // Validate same skill not already added
            var existingSkill = await _dbContext.EmployeeSkills
                .FirstOrDefaultAsync(es => es.EmployeeId == employeeSkill.EmployeeId && es.SkillName == employeeSkill.SkillName && es.CustomerId == employeeSkill.CustomerId);

            if (existingSkill != null)
            {
                return Conflict($"Skill '{employeeSkill.SkillName}' already exists for Employee ID {employeeSkill.EmployeeId}.");
            }

            var skill = new EmployeeSkill
            {
                EmployeeId = employeeSkill.EmployeeId,
                CustomerId = employeeSkill.CustomerId,
                Employee = employee,
                SkillName = employeeSkill.SkillName,
                Rating = employeeSkill.Rating
            };

            _dbContext.EmployeeSkills.Add(skill);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { employeeId = employeeSkill.EmployeeId }, employeeSkill);
        }
    }
}
