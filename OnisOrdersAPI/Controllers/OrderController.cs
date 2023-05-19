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
            try 
            {
                IEnumerable<OrderItemDto> orderDtos = await _orderRepository.GetOrders();
                _response.Result = orderDtos;
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            
            

            return _response;
        }

        [HttpGet]
        
        [Route("{id}")]

        public async Task<object> Get(int id)
        {


            try
            {
                OrderItemDto orderDtos = await _orderRepository.GetOrderById(id);
                _response.Result = orderDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            



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


            try
            {
                bool isSuccess = await _orderRepository.DeleteOrder(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


    }
}
