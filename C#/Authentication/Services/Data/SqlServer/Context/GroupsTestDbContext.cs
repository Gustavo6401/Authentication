using Authentication.Services.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Data.SqlServer.Context;

public class GroupsTestDbContext : DbContext
{
    public GroupsTestDbContext(DbContextOptions<GroupsTestDbContext> options) : base(options) { }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioGroup> UsuarioGroups { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Group>()
            .HasKey(g => g.Id);

        modelBuilder.Entity<Group>()
            .Property(g => g.Name)
                .IsRequired()
                    .HasMaxLength(200);

        modelBuilder.Entity<Group>()
            .Property(g => g.IsPublic)
                .IsRequired();

        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.UserName)
                .IsRequired()
                    .HasMaxLength(100);
        
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Email)
                .IsRequired()
                    .HasMaxLength(200);

        modelBuilder.Entity<UsuarioGroup>()
            .HasKey(ug => ug.Id);

        modelBuilder.Entity<UsuarioGroup>()
            .Property(ug => ug.Role)
                .IsRequired()
                    .HasMaxLength(30);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.Usuarios)
                .WithMany(u => u.Groups)
                    .UsingEntity<UsuarioGroup>();
    }
}