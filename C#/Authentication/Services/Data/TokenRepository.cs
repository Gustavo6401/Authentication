using MongoDB.Driver;

namespace Authorization.Services.Data;

public class TokenRepository {
    private readonly IMongoClient mongoClient;
    private readonly IMongoDatabase mongoDatabase;
    private readonly IMongoCollection<TokenData> mongoCollection;
    public TokenRepository()
    {
        mongoClient = new MongoClient("mongodb://localhost:27017");
        mongoDatabase = mongoClient.GetDatabase("TokensTestDB");

        mongoCollection = mongoDatabase.GetCollection<TokenData>("TokensTest");
    }

    public void Create(Guid userId, string token) 
    {
        TokenData tokenData = new TokenData 
        {
            Token = token,
            DataCriacaoToken = DateTime.Now,
            UsuarioId = userId.ToString()
        };

        mongoCollection.InsertOne(tokenData);
    }
}