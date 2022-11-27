namespace PriceBuddy.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Roles { get; set; }
    public bool Active { get; set; }
}
