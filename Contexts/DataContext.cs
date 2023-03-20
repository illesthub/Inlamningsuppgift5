using Arendehanteringssystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arendehanteringssystem.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\morkj\Documents\SQL_Database.mdf;Integrated Security=True;Connect Timeout=30";
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ErrandEntity>()
            .HasOne(e => e.Customer)
            .WithMany(c => c.Errands)
            .HasForeignKey(e => e.CustomerId);

        modelBuilder.Entity<StatusAndCommentEntity>()
            .HasOne(e => e.Errand)
            .WithOne(c => c.StatusAndComment);

    }



    public DbSet<CustomerEntity> Customer { get; set; } = null!;
    public DbSet<ErrandEntity> Errand { get; set; } = null!;
    public DbSet<StatusAndCommentEntity> StatusAndComment { get; set; } = null!;

}
