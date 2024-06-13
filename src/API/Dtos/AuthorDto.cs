using Core.Models;

namespace API.Dtos;

public class AuthorDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Author AsModel()
    {
        return new()
        {
            FirstName = FirstName,
            LastName = LastName
        };
    }
}
