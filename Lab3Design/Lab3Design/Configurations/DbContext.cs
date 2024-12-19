using Microsoft.EntityFrameworkCore;
using Lab3Design.Models.Songs;

namespace Lab3Design.Configurations;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Song> songs { get; set; }

    private readonly IConfiguration _configuration;

    public DbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbConnectionString = _configuration.GetConnectionString("DbConnectionString");
        optionsBuilder.UseNpgsql(dbConnectionString);
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
