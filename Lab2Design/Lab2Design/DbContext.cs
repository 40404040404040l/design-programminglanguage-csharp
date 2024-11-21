using Lab2Design.SongDirectory;
using Microsoft.EntityFrameworkCore;

namespace Lab2Design;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Song> songs { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=myuser;Password=123123;Host=localhost;Port=5432;Database=postgres;");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>(builder =>
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.Name).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Author).IsRequired().HasMaxLength(255);
        });
    }
}