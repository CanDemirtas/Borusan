
using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Profiles;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {

        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;


        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _logger.LogInformation("Hello, world!");
            _logger.LogError("Hello, world!");

        }

        [HttpPost("AcceptOrders")]
        public async Task<ActionResult> AcceptOrders([FromBody] OrderViewModel model)
        {
            try
            {
                var data = _orderService.SaveOrders(model);
                return Ok(data);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        
        }
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult> UpdateStatus([FromBody] List<OrderViewModel> model)
        {
            try
            {
                var result = await _orderService.UpdateOrderStatus(model);
                return Ok(result);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPost("FetchOrders")]
        public async Task<ActionResult> FetchOrders()
        {
            try
            {
                var data = await _orderService.FetchOrders();

                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}
