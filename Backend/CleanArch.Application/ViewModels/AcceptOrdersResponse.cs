using System;

namespace CleanArch.Application.ViewModels
{
    public class AcceptOrdersResponse : BaseViewModel<Guid>
    {
        public string CustomerOrderNumber { get; set; }
        public string ErrorMessage { get; set; }
        public Status Status { get; set; } = Status.Success;

    }
    //Id sistem sipariş nodur.CustomerOrderNumber müşteri sipariş nodur.
    public enum Status
    {
        Success,
        Failed
    }

}
