using System;
using System.Collections.Generic;

namespace Indivuellt_projekt_Databas.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int Ssn { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
    }
}
