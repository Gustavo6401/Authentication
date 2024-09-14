using Authentication.Services.Data.Models;
using Authentication.Services.Data.Repository.Base;
using Authentication.Services.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Data.Repository;

public class UserRepository : RepositoryBase<Usuario>
{
    private readonly GroupsTestDbContext context;
    public UserRepository() 
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=GroupsTest;Trusted_Connection=True;";

        context = new GroupsTestDbContext(new DbContextOptionsBuilder<GroupsTestDbContext>()
            .UseSqlServer(connectionString)
            .Options);        
    }

    public async Task<Usuario> Get(Guid id)
    {
        Usuario? user = await context.Usuarios.FindAsync(id);

        return user!;
    }

    public async Task<Usuario> GetByEmail(string email) 
    {
        Usuario? user = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

        return user!;
    }
}