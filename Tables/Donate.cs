using System;
using System.Collections.Generic;

namespace EarthFront.Tables
{
    public partial class Donate
    {
        public int Sn { get; set; }
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string CorpId { get; set; } = null!;
        public decimal DonateCoin { get; set; }
        public decimal RemainCoin { get; set; }
        public DateTime Created { get; set; }
    }
}
