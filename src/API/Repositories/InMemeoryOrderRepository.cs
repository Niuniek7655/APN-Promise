using API.Abstractions;
using API.Models;

namespace API.Repositories;

public class InMemeoryOrderRepository : IOrderRepository
{
    //Not thread-safe, use Concurrent collections
    private readonly IEnumerable<Order> _orders = new List<Order>()
    {
        new Order
        {
            OrderId = Guid.NewGuid(),
            OrderLines = new List<OrderLine>()
            {
                new OrderLine
                {
                    BookId = 1,
                    Quantity = 10
                },
                new OrderLine
                {
                    BookId = 2,
                    Quantity = 20
                },
            }
        },
        new Order
        {
            OrderId = Guid.NewGuid(),
            OrderLines = new List<OrderLine>()
            {
                new OrderLine
                {
                    BookId = 3,
                    Quantity = 40
                },
                new OrderLine
                {
                    BookId = 4,
                    Quantity = 30
                },
            }
        },
        new Order
        {
            OrderId = Guid.NewGuid(),
            OrderLines = new List<OrderLine>()
            {
                new OrderLine
                {
                    BookId = 5,
                    Quantity = 5
                },
                new OrderLine
                {
                    BookId = 7,
                    Quantity = 80
                },
            }
        }
    };

    public Task<IEnumerable<Order>> GetOrders(int pageNumber, int pageSize)
    {
        var orders = _orders
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return Task.FromResult(orders);
    }
}
