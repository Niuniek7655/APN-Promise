using API.Abstractions;
using API.Dtos;

namespace API.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderDto>> GetOrders(int pageNumber, int pageSize)
    {
        var orders = await _orderRepository.GetOrders(pageNumber, pageSize);
        var result = orders.Select(x => x.AsDto());
        return result;
    }
}
