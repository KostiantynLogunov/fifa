using System;

namespace FIFA.Domain
{
    public class Footballer
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Team { get; set; }
        public string? OVR { get; set; }
        public string? POS { get; set; }
        public string? BIN{ get; set; }
        public string? PAC{ get; set; }
        public string? SHO{ get; set; }
        public string? PAS{ get; set; }
        public string? DRI{ get; set; }
        public string? DEF{ get; set; }
        public string? PHY { get; set; }
        public string? SM { get; set; }
        public string? WF { get; set; }
        public string? WRs { get; set; }
        public string? Foot { get; set; }
        public string? Stats { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    }
}
