using System;
using System.Collections.Generic;

namespace EarthFront.Tables
{
    public partial class UserFront
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Account { get; set; }
        public string? Pwd { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
    }
}
