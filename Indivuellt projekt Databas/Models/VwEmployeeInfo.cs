using System;
using System.Collections.Generic;

namespace Indivuellt_projekt_Databas.Models
{
    public partial class VwEmployeeInfo
    {
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int? Years { get; set; }
    }
}
