namespace Authentication.Services.Data.Models; 

public class Group 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsPublic { get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }
}