using Booking.Auth.Srv.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        CreateDefaultAdmin(modelBuilder);
    }
    
    private void CreateDefaultAdmin(ModelBuilder builder)
    {
        builder.Entity<User>().HasData(new User
        {
            Id = Guid.NewGuid(),
            Login = "admin",
            Email = "dadkova-anna@mail.ru",
            PasswordHash = "AQAAAAIAAYagAAAAEHpX9YRUx2LHWG4N5dxWszz3Cgn1mdFl6f5l3slTKrMmqFodCjz7abc564LoKqS98w==",

            LastName = "Фамилия",
            FirstName = "Имя",
            MiddleName = "Отчество",

            EmailConfirmed = true,
            PhoneNumber = "5553555"
        });
    }
}