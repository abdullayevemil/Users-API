namespace Users_API.Core.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly? BirthDate { get; set; }
    public Book[]? Books { get; set; }
}