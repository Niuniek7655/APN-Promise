using API.Models;
using Core.Models;

namespace API.Dtos;

public static class Extensions
{
    public static BookDto AsDto(this Book book)
    {
        return new()
        {
            Id = book.Id,
            Title = book.Title,
            Price = book.Price,
            Bookstand = book.Bookstand,
            Shelf = book.Shelf,
            Authors = book.Authors.Select(x => x.AsDto())
        };
    }

    public static AuthorDto AsDto(this Author author)
    {
        return new()
        {
            FirstName = author.FirstName,
            LastName = author.LastName,
        };
    }

    public static OrderDto AsDto(this Order order)
    {
        return new()
        {
            OrderId = order.OrderId.ToString(),
            OrderLines = order.OrderLines.Select(x => x.AsDto())
        };
    }

    public static OrderLineDto AsDto(this OrderLine orderLine)
    {
        return new()
        {
            BookId = orderLine.BookId,
            Quantity = orderLine.Quantity,
        };
    }
}