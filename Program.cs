using Microsoft.EntityFrameworkCore;
using test_dot.Data;
using test_dot.Services;
using test_dot.SignalR;
using test_dot.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.Configure<RabbitMqConfiguration>(a=>builder.Configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();


builder.Services.AddSingleton<IBookingConsumerService, BookingConsumerService>();

builder.Services.AddSingleton<INotificationHub, NotificationHub>();

builder.Services.AddHostedService<ConsumerHostedService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});

builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// UseCors must be called before MapHub.
app.UseCors();

app.MapControllers();
app.MapHub<NotificationHub>("/notification", option =>
{
    option.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.ServerSentEvents;
});
app.MapHub<DateTimeHub>("/dateTime");

app.Run();
