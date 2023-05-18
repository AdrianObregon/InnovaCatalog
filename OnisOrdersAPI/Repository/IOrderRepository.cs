using OnisOrdersAPI.Models.Dto;

namespace OnisOrdersAPI.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderItemDto>> GetOrders();
        Task<OrderItemDto> GetOrderById(int orderId);
        Task<OrderItemDto> CreateUpdateOrder(OrderItemDto orderDto);
        Task<bool> DeleteOrder(int orderId);
    }
}
