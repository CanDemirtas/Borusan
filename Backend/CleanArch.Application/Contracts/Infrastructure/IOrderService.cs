using CleanArch.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Infrastructure
{
    public interface IOrderService
    {
        Task<OrderViewModel> SaveOrders(OrderViewModel model);
        Task<List<OrderViewModel>> FetchOrders();
        Task<List<OrderViewModel>> UpdateOrderStatus(List<OrderViewModel> orderList);
    }
}
