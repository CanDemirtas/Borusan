using System;

namespace CleanArch.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; } = "can";
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
    }
}
