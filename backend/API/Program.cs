global using API.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // In development mode, allow any https request
    app.UseCors(builder =>
    {
        builder.WithOrigins("http://localhost:8080")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
