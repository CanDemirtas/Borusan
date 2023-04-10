using AutoMapper;
using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<OrderService> _logger;

        public OrderService(IUnitOfWork unitOfWork,ILogger<OrderService> logger, IOrderRepository orderRepository, IMaterialRepository materialRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public async Task<List<OrderViewModel>> FetchOrders()
        {
            try
            {
                var result = await _unitOfWork._orderRepository.ListAllAsync();
                var orderList = _mapper.Map<List<OrderViewModel>>(result);
                return orderList;
            }
            catch (Exception e)
            {

                _logger.LogError("Order Service FetchOrders:"+e.Message);
                return new List<OrderViewModel>();

            }
        }

        public async Task<List<OrderViewModel>> UpdateOrderStatus(List<OrderViewModel> orderList)
        {
            var orderIdList = orderList.Select(a => a.CustomerOrderNumber).ToList();
            var status = orderList.FirstOrDefault().Status;

            try
            {
                var orderListDb = _unitOfWork._orderRepository.GetQueryable().Where(a => orderIdList.Contains(a.CustomerOrderNumber)).ToList();

                var willBeUpdateList = orderListDb.Select(a => { a.Status = status; return a; }).ToList();

                foreach (var order in willBeUpdateList)
                {
                    await _unitOfWork._orderRepository.UpdateAsync(order);
                }
                await _unitOfWork._orderRepository.SaveChangesAsync();

                return orderList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return new List<OrderViewModel>();
        }

        public async Task<List<AcceptOrdersResponse>> SaveOrders(List<OrderViewModel> list)
        {
            try
            {
                var acceptOrdersResponseList = new List<AcceptOrdersResponse>();

                foreach (var model in list)
                {
                    var acceptOrdersResponse = new AcceptOrdersResponse();

                    var isExistOrder = _unitOfWork._orderRepository.GetQueryable().Any(a => a.CustomerOrderNumber == model.CustomerOrderNumber);
                    if (isExistOrder)
                    {
                        acceptOrdersResponse.CustomerOrderNumber = model.CustomerOrderNumber;
                        acceptOrdersResponse.ErrorMessage = "Aynı sipariş kodunda kayıt mevcut!";
                        acceptOrdersResponse.Status = Status.Failed;
                        acceptOrdersResponseList.Add(acceptOrdersResponse);
                        continue;
                    }
                
                    var order = _mapper.Map<Domain.Entities.Order>(model);
                    order.Material.Id = Guid.NewGuid();
                    var existingMaterial = _unitOfWork._materialRepository.GetQueryable().FirstOrDefault(a => a.Code == order.Material.Code);
                    if (existingMaterial != null)
                    {
                        order.Material = null;
                        order.MaterialCode = existingMaterial.Code;
                    }


                    await _unitOfWork._orderRepository.AddAsyncWithSaveChangesAsync(order);

                    acceptOrdersResponse.Id = order.Id;
                    acceptOrdersResponse.CustomerOrderNumber = order.CustomerOrderNumber;
                    acceptOrdersResponseList.Add(acceptOrdersResponse);
                }

              
                return acceptOrdersResponseList;
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);

                return new List<AcceptOrdersResponse>() { new AcceptOrdersResponse() { Status = Status.Failed, ErrorMessage = e.Message } };

            }

        }

 


    }
}
