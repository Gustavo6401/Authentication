using MongoDB.Bson;

namespace Authorization.Services.Data;

public class TokenData 
{
    public ObjectId Id { get; set; }
    public string? Token { get; set; }
    public DateTime? DataCriacaoToken { get; set; }
    public string? IPv4 { get; set; }
    public string? IPv6 { get; set; }
    public string? UsuarioId { get; set; }
}