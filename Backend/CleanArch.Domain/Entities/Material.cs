using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanArch.Domain.Common;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    [Table("Materials")]
    public class Material : BaseEntity<Guid>
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}

