using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crud_app.Models;

public partial class Employee
{
    [Key]
    public int EmpId { get; set; }

    [Required]
    public string? EmpName { get; set; }

    public int? Age { get; set; }

    public string? EmpDesc { get; set; }
}
