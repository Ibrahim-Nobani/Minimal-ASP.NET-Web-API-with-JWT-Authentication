using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Models;
namespace MinimalWebApi.Database;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}