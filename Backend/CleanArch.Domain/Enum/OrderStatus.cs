using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Enum
{
    public enum OrderStatus
    {
        Received,
        OnTheWay,
        AtDistributionCenter,
        OutForDelivery,
        Delivered,
        DeliveryFailed
    }
}
