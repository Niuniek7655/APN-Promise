using Lib.Abstractions;
using Lib.Dtos;

namespace Lib.Consumers;

internal class OrdersControllerConsumer : IOrdersControllerConsumer
{
    private readonly IApiService _apiService;
    public OrdersControllerConsumer(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IEnumerable<OrderDto>> GetOrders(int pageNumber, int pageSize)
    {
        return await _apiService.GetOrders(pageNumber, pageSize);
    }
}
