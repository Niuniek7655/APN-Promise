using Core.Models;

namespace API.Dtos;

public class BookDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public long Bookstand { get; set; }
    public long Shelf { get; set; }
    public IEnumerable<AuthorDto> Authors { get; set; } = Enumerable.Empty<AuthorDto>();

    public Book AsModel()
    {
        return new()
        {
            Id = Id,
            Title = Title,
            Price = Price,
            Bookstand = Bookstand,
            Shelf = Shelf,
            Authors = Authors.Select(x => x.AsModel())
        };
    }
}