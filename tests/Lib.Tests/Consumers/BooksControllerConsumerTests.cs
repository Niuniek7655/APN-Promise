using FluentAssertions;
using Lib.Abstractions;
using Lib.Consumers;
using Lib.Dtos;
using Moq;

namespace Lib.Tests.Consumers;

public class BooksControllerConsumerTests
{
    private Mock<IApiService> _apiServiceMock = new Mock<IApiService>();
    private BooksControllerConsumer _consumer;
    public BooksControllerConsumerTests()
    {
        _consumer = new BooksControllerConsumer(_apiServiceMock.Object);
    }

    [Fact]
    public async Task GetBooks__When_invoke_method__Should_return_books()
    {
        IEnumerable<BookDto> books = new List<BookDto>()
        {
            new BookDto()
            {
                Id = 1,
                Title = "Test1",
                Price = 100,
                Bookstand = 1,
                Shelf = 1,
                Authors = new List<AuthorDto>()
                {
                    new()
                    {
                        FirstName = "Test1",
                        LastName = "Test1",
                    }
                }
            }
        };

        _apiServiceMock
            .Setup(x => x.GetBooks())
            .ReturnsAsync(books);

        var result = await _consumer.GetBooks();

        result.Should().Contain(books);
        _apiServiceMock.Verify(x => x.GetBooks(), Times.Once());
    }

    [Fact]
    public async Task CreateBook__When_invoke_method__Should_call_the_CreateBook_method_from_the_IApiService()
    {
        BookDto newBook = new BookDto()
        {
            Id = 2,
            Title = "Test2",
            Price = 200,
            Bookstand = 2,
            Shelf = 2,
            Authors = new List<AuthorDto>()
            {
                new()
                {
                    FirstName = "Test2",
                    LastName = "Test2",
                }
            }
        };

        await _consumer.CreateBook(newBook);

        _apiServiceMock.Verify(x => x.CreateBook(newBook), Times.Once());
    }
}
