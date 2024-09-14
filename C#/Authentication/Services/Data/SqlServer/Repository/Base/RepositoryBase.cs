using Authentication.Services.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Data.Repository.Base;

public class RepositoryBase<T> where T : class
{
    private readonly GroupsTestDbContext context;
    public RepositoryBase() 
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=GroupsTest;Trusted_Connection=True;";

        context = new GroupsTestDbContext(new DbContextOptionsBuilder<GroupsTestDbContext>()
            .UseSqlServer(connectionString)
            .Options);
    }

    public virtual async Task CreateAsync(T entity) 
    {
        context.Set<T>()
            .Add(entity);

        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity) 
    {
        context.Set<T>()
            .Update(entity);

        await context.SaveChangesAsync();
    }
}