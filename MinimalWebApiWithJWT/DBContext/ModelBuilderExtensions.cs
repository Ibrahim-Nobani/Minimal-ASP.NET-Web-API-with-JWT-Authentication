using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Models;
namespace MinimalWebApi.Database;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "John", LastName = "Doe", UserName = "john.doe", Password = "password1" },
            new User { Id = 2, FirstName = "Jane", LastName = "Doe", UserName = "jane.doe", Password = "password2" },
            new User { Id = 3, FirstName = "Alice", LastName = "Smith", UserName = "alice.smith", Password = "password3" },
            new User { Id = 4, FirstName = "Bob", LastName = "Johnson", UserName = "bob.johnson", Password = "password4" },
            new User { Id = 5, FirstName = "Eve", LastName = "Brown", UserName = "eve.brown", Password = "password5" }
        );
    }
}
