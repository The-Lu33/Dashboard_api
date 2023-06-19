using Dashboard_api.Models;
using Dashboard_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DB>(
    builder.Configuration.GetSection("MyDb")
    );
Console.WriteLine("Database conn");
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IMovementsService, MovementsService>();
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
