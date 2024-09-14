namespace Authentication.Services.Data.Models;

public class Usuario 
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

    public ICollection<Group>? Groups { get; set; }
}