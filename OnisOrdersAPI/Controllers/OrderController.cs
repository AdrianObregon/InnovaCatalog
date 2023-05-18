using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnisOrdersAPI.Models.Dto;
using OnisOrdersAPI.Repository;

namespace OnisOrdersAPI.Controllers
{
    [Route("api/OrdersAPI")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        protected ResponseDto _response;
        private IOrderRepository  _orderRepository;
        
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            IEnumerable<OrderItemDto> orderDtos = await _orderRepository.GetOrders();
            _response.Result = orderDtos;
            

            return Ok(_response);
        }

        [HttpGet]
        
        [Route("{id}")]

        public async Task<object> Get(int id)
        {


            OrderItemDto orderDtos = await _orderRepository.GetOrderById(id);
            _response.Result = orderDtos;
            



            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] OrderItemDto orderDto)
        {


            OrderItemDto model = await _orderRepository.CreateUpdateOrder(orderDto);
            _response.Result = model;
            





            return _response;
        }

        [HttpPut]
        

        public async Task<object> Put([FromBody] OrderItemDto orderDto)
        {


            OrderItemDto model = await _orderRepository.CreateUpdateOrder(orderDto);
            _response.Result = model;
            



            return _response;
        }


        [HttpDelete]
        [Route("{id}")]
        
        public async Task<object> Delete(int id)
        {



            bool isSuccess = await _orderRepository.DeleteOrder(id);
            _response.Result = isSuccess;
            



            return _response;
        }


    }
}
