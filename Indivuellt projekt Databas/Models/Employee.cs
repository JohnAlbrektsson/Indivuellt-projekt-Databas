using System;
using System.Collections.Generic;

namespace Indivuellt_projekt_Databas.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
    }
}
