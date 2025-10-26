using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillsManagement.DTO;
using System.ComponentModel.DataAnnotations;

namespace SkillsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly SkillsDbContext _skillsDbContext;

        public ReportsController(SkillsDbContext skillsDbContext)
        {
            _skillsDbContext = skillsDbContext;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<SkillReport>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSkillsReport([Required]int customerId)
        {
            var reports = await _skillsDbContext
                .Set<SkillReport>()
                .FromSqlRaw("EXEC GetSkillReport @CustomerId={0}", customerId)
                .ToListAsync();

            return Ok(reports);
        }
    }
}
