using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VacationManagementAPI.Models
{
    // Модель для Организации
    public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}

public class Position
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class VacationType
{
    public int Id { get; set; }
    public string TypeName { get; set; }
}

public class EmployeeVacationDays
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int VacationTypeId { get; set; }
    public int Days { get; set; }
    public Employee Employee { get; set; }
    public VacationType VacationType { get; set; }
}

public class Holiday
{
    public int Id { get; set; }
    public DateTime HolidayDate { get; set; }
}

public class Restriction
{
    public int Id { get; set; }
    public string Type { get; set; }
}

public class DepartmentRestriction
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int RestrictionId { get; set; }
    public Department Department { get; set; }
    public Restriction Restriction { get; set; }
}

public class ScheduledVacation
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Employee Employee { get; set; }
}
}