using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanArch.Domain.Common;
using System;
using CleanArch.Domain.Enum;

namespace CleanArch.Domain.Entities
{

    [Table("Orders")]
    public class Order : BaseEntity<Guid>
    {
 
        [Required]
        public string CustomerOrderNumber { get; set; }

        [Required]
        public string DepartureAddress { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public QuantityUnit QuantityUnit { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public WeightUnit WeightUnit { get; set; }

        public string Note { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public string MaterialCode { get; set; }

        [ForeignKey("MaterialCode")]
        public Material Material { get; set; }
    }
}

