using Reservations;
using System.Collections.Generic;
using System.Reflection.Emit;
using Tables;

namespace DataContext
{
    //public class DataContext : DbContext
    //{
    //    // public DbSet<КлассОписывающийЗаписьВТаблице> названиеБудущейТаблицы { get; set; }
    //    public DbSet<TableEntity> Tables { get; set; }
    //    public DbSet<ReservationEntity> Reservations{ get; set; }

    //    public DataContext()
    //    {
    //        Database.EnsureCreated();
    //    }

    //    //создание связей между таблицами
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<TableEntity>()
    //            .HasMany(t => t.Reservations)   // У стола много заказов
    //            .WithOne(r => r.TableId)        // У каждого заказа есть один стол
    //            .HasForeignKey(r => r.Id);      // Внешний ключ в таблице заказов
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseNpgsql("Host=localhost;Port=54432;Username=postgres;Password=PASSWORD;Database=Otus.HW_DB1");

    //        base.OnConfiguring(optionsBuilder);
    //    }
    //}
}
