using AutoMapper;
using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Infrastructure.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService( ILogger<OrderService> logger, IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

        }

        public async Task<List<OrderViewModel>> FetchOrders()
        {
            try
            {
                var result = await _orderRepository.ListAllAsync();
                var orderList = _mapper.Map<List<OrderViewModel>>(result);
                return orderList;
            }
            catch (Exception e)
            {

                
            }
            return new List<OrderViewModel>();
        }

        public async Task<List<OrderViewModel>> UpdateOrderStatus(List<OrderViewModel> orderList)
        {
            var orderIdList = orderList.Select(a => a.CustomerOrderNumber).ToList();
            var status = orderList.FirstOrDefault().Status;

            try
            {
                var orderListDb = _orderRepository.GetQueryable().Where(a => orderIdList.Contains(a.CustomerOrderNumber)).ToList();

               var willBeUpdateList= orderListDb.Select(a => { a.Status = status; return a; }).ToList();

                foreach (var order in willBeUpdateList) {

                    await _orderRepository.UpdateAsync(order);
                }
                await _orderRepository.SaveChangesAsync();

                return orderList;
            }
            catch (Exception e)
            {


            }
            return new List<OrderViewModel>();
        }
        public async Task<OrderViewModel> SaveOrders(OrderViewModel model)
        {

            try
            {
                var order = _mapper.Map<Domain.Entities.Order>(model);

                var result = await _orderRepository.AddAsync(order);

                return model;
            }
            catch (System.Exception e)
            {

             
            }
            return model;
        }

       
    }
}
