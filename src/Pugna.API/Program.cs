using Npgsql;
using Pugna.Core.Rooms;
using Pugna.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var  connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddSingleton(_ => NpgsqlDataSource.Create(connectionString)); // Create a singleton instance so that the same instance is used throughout the application. It is used by other files (such as PostgresRoomRepository) through DI

builder.Services.AddScoped<IRoomRepository, RoomRepository>(); // Register the RoomRepository as the implementation of IRoomRepository. It is used by other files (such as RoomController) through DI
builder.Services.AddScoped<RoomService>(); // Add RoomService to RoomController when it requests it

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
