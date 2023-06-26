using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add database context
builder.Services.AddDbContext<TodoContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    //builder.Services.AddDbContext<TodoContext>(options =>
    // options.UseSqlite(
    //     Configuration.GetConnectionString("RazorPagesMovieContext")));

}
else

    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
