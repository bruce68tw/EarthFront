using System;
using System.Collections.Generic;

namespace EarthFront.Tables
{
    public partial class Act
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string DonateId { get; set; } = null!;
        public string? Caption { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal PlanCoin { get; set; }
        public decimal RealCoin { get; set; }
        public int PlanUsers { get; set; }
        public int RealUsers { get; set; }
        public string? FileName { get; set; }
        public string? Note { get; set; }
        public bool Issued { get; set; }
        public bool Status { get; set; }
        public string Creator { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime? Revised { get; set; }
    }
}
