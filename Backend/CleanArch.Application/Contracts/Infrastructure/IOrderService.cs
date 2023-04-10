using CleanArch.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Infrastructure
{
    public interface IOrderService
    {
        Task<List<AcceptOrdersResponse>> SaveOrders(List<OrderViewModel> list);
        Task<List<OrderViewModel>> FetchOrders();
        Task<List<OrderViewModel>> UpdateOrderStatus(List<OrderViewModel> orderList);
    }
}
