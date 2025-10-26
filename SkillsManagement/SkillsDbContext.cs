using Microsoft.EntityFrameworkCore;
using SkillsManagement.DTO;
using SkillsManagement.Entities;

namespace SkillsManagement
{
    public class SkillsDbContext: DbContext
    {
        public SkillsDbContext(DbContextOptions<SkillsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillReport>().HasNoKey();
        }
    }
}
