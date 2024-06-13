using API.Models;

namespace API.Abstractions;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetOrders(int pageNumber, int pageSize);
}
