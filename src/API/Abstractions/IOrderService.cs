using API.Dtos;

namespace API.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetOrders(int pageNumber, int pageSize);
}
