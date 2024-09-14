using Authentication.Services.Data.Models;
using Authentication.Services.Data.Repository.Base;
using Authentication.Services.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Data.Repository;

public class GroupUserRepository : RepositoryBase<UsuarioGroup>
{
    private readonly GroupsTestDbContext context;
    public GroupUserRepository() 
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=GroupsTest;Trusted_Connection=True;";

        context = new GroupsTestDbContext(new DbContextOptionsBuilder<GroupsTestDbContext>()
            .UseSqlServer(connectionString)
            .Options);        
    }

    public async Task<List<UsuarioGroup>> GetGroupsByUsuarioId(Guid userId)
    {
        List<UsuarioGroup>? userGroup = await context.UsuarioGroups.Where(u => u.UsuarioId == userId)
            .ToListAsync();

        return userGroup!;
    }
}