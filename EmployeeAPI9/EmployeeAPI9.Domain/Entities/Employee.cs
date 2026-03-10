using System;
using System.Collections.Generic;

namespace EmployeeAPI9.Domain.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public float Salary { get; set; }
}
