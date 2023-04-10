
using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Profiles;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        [HttpPost("AcceptOrders")]
        public async Task<ActionResult> AcceptOrders([FromBody] List<OrderViewModel> model)
        {
            try
            {
                var data = await _orderService.SaveOrders(model);

                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            }
            catch (System.Exception e)
            {
                _logger.LogError("AcceptOrders Controller Method Error:"+e.Message);

                return BadRequest(e.Message);
            }       
        }

        [HttpPost("UpdateStatus")]
        public async Task<ActionResult> UpdateStatus([FromBody] List<OrderViewModel> model)
        {
            try
            {
                var result = await _orderService.UpdateOrderStatus(model);
                //http call yada signalr üzerinden entegrasyon..
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }
            catch (System.Exception e)
            {
                _logger.LogError("UpdateStatus Controller Method Error:" + e.Message);

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
                _logger.LogError("UpdateStatus Controller Method Error:" + e.Message);

                return BadRequest(e.Message);
            }

        }


    }
}
