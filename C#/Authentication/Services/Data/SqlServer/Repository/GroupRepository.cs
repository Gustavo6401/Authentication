using Authentication.Services.Data.Models;
using Authentication.Services.Data.Repository.Base;
using Authentication.Services.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Data.Repository;

public class GroupRepository : RepositoryBase<Group>
{
    private readonly GroupsTestDbContext context;
    public GroupRepository() 
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=GroupsTest;Trusted_Connection=True;";

        context = new GroupsTestDbContext(new DbContextOptionsBuilder<GroupsTestDbContext>()
            .UseSqlServer(connectionString)
            .Options);        
    }

    public async Task<Group> GetAsync(int id) 
    {
        Group? group = await context.Groups.FindAsync(id);

        return group!;
    }
}