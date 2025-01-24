using BlazorAppServer.Components.Pages;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorAppServer;

public class StudentsAffairsDbContext : DbContext
{
    public StudentsAffairsDbContext(DbContextOptions<StudentsAffairsDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Staff> FacultyStaff { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
