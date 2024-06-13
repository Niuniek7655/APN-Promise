using FluentAssertions;
using Lib.Abstractions;
using Lib.Consumers;
using Lib.Dtos;
using Moq;

namespace Lib.Tests.Consumers;

public class OrdersControllerConsumerTests
{
    private Mock<IApiService> _apiServiceMock = new Mock<IApiService>();
    private OrdersControllerConsumer _consumer;
    public OrdersControllerConsumerTests()
    {
        _consumer = new OrdersControllerConsumer(_apiServiceMock.Object);
    }

    private IEnumerable<OrderDto> _expectedOrders = new List<OrderDto>()
    {
         new OrderDto
        {
            OrderId = "3",
            OrderLines = new List<OrderLineDto>()
            {
                new OrderLineDto
                {
                    BookId = 5,
                    Quantity = 5
                },
                new OrderLineDto
                {
                    BookId = 7,
                    Quantity = 80
                },
            }
        },
        new OrderDto
        {
            OrderId = "4",
            OrderLines = new List<OrderLineDto>()
            {
                new OrderLineDto
                {
                    BookId = 15,
                    Quantity = 45
                },
                new OrderLineDto
                {
                    BookId = 37,
                    Quantity = 280
                },
            }
        }
    };

    [Fact]
    public async Task GetOrders__When_call_the_method_with_a_specific_page_number_and_the_number_of_items_on_it__Should_return_the_specified_number_of_items_from_that_page()
    {
        _apiServiceMock
            .Setup(x => x.GetOrders(1, 2))
            .ReturnsAsync(_expectedOrders);

        var result = await _consumer.GetOrders(1, 2);

        result.Should().Contain(_expectedOrders);
        _apiServiceMock.Verify(x => x.GetOrders(1, 2), Times.Once());
    }
}
