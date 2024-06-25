using _2___ConsumidorEmail.Application;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));

    cfg.ReceiveEndpoint("enviar-email", e =>
    {
        e.Consumer<ApplicationConsumidor>();
    });
});

busControl.StartAsync();

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
