using Bogus;

namespace Pagination.Models;

public class Usuarios
{
    public int Id { get; set; } = 0;
    public string Random => new Faker().Lorem.Sentence();
}