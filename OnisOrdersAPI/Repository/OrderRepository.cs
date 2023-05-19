using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnisOrdersAPI.DbContexts;
using OnisOrdersAPI.Models;
using OnisOrdersAPI.Models.Dto;

namespace OnisOrdersAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public OrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrderItemDto> CreateUpdateOrder(OrderItemDto orderDto)
        {
            OrderItem orderItem = _mapper.Map<OrderItemDto, OrderItem>(orderDto);
            if (orderItem.OrderId > 0)// si mayor a 0, es update porque ya existe
            {
                _db.OrderItem.Update(orderItem);
            }
            else
            {
                _db.OrderItem.Add(orderItem);
            }
            await _db.SaveChangesAsync();
            //Convertir Modelo a Dto
            return _mapper.Map<OrderItem, OrderItemDto>(orderItem);
        }

        public async Task<bool> DeleteOrder(int orderItemId)
        {
            try
            {
                OrderItem orderItem = await _db.OrderItem.FirstOrDefaultAsync(u => u.OrderItemId == orderItemId);
                if (orderItem == null)
                {
                    return false;
                }
                _db.OrderItem.Remove(orderItem);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<OrderItemDto> GetOrderById(int orderId)
        {
            OrderItem orderItem = await _db.OrderItem.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<IEnumerable<OrderItemDto>> GetOrders()
        {
            List<OrderItem> orderItem = await _db.OrderItem.ToListAsync();
            return _mapper.Map<List<OrderItemDto>>(orderItem);//order item a catalog DTO
        }
    }
}
