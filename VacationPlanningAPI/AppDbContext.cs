using Microsoft.EntityFrameworkCore;
using VacationManagementAPI.Models; 

public class VacationPlanningContext : DbContext
{
    public VacationPlanningContext(DbContextOptions<VacationPlanningContext> options) : base(options) { }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<VacationType> VacationTypes { get; set; }
    public DbSet<EmployeeVacationDays> EmployeeVacationDays { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<Restriction> Restrictions { get; set; }
    public DbSet<DepartmentRestriction> DepartmentRestrictions { get; set; }
    public DbSet<ScheduledVacation> ScheduledVacations { get; set; }
}
