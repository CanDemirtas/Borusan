using System.ComponentModel.DataAnnotations;

namespace CleanArch.Domain.Common
{
    public abstract class BaseEntity<TKey> : AuditableEntity
    {
        [Key]
        public TKey Id { get; set; }

    }
}
