using System;
using System.Collections.Generic;

namespace Indivuellt_projekt_Databas.Models
{
    public partial class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime GradeDate { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Grade Grade { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
