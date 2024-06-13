using Lib.Dtos;

namespace Lib.Abstractions;

public interface IOrdersControllerConsumer
{
    Task<IEnumerable<OrderDto>> GetOrders(int pageNumber, int pageSize);
}
