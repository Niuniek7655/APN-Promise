namespace API.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public IEnumerable<OrderLine> OrderLines { get; set; } = Enumerable.Empty<OrderLine>();
}
