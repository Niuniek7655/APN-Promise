namespace API.Dtos;

public class OrderDto
{
    public string OrderId { get; set; } = string.Empty;
    public IEnumerable<OrderLineDto> OrderLines { get; set; } = Enumerable.Empty<OrderLineDto>();
}
