namespace Authentication.Services.Data.Models;

public class UsuarioGroup 
{
    public int Id { get; set; }
    public string? Role { get; set; }

    public Usuario? Usuario { get; set; }
    public Guid UsuarioId { get; set; }

    public Group? Group { get; set; }
    public int GroupId { get; set; }
}