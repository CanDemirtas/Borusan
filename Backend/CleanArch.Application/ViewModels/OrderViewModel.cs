using CleanArch.Domain.Entities;
using CleanArch.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CleanArch.Application.ViewModels
{
    public class OrderViewModel : BaseViewModel<Guid>
    {
        public string CustomerOrderNumber { get; set; }
        public string DepartureAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal Quantity { get; set; }
        public QuantityUnit QuantityUnit { get; set; }
        public decimal Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public OrderStatus Status { get; set; }
        public MaterialViewModel Material { get; set; }
        public string Note { get; set; }

    }


}
