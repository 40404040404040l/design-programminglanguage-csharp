using Lab3Design.Models.SongCatalogs;
using Microsoft.EntityFrameworkCore;
using DbContext = Lab3Design.Configurations.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with dependency injection
builder.Services.AddDbContext<DbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
    NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(options, connectionString);
});

builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();