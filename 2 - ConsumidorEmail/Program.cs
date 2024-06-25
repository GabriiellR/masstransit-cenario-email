using _2___ConsumidorEmail.ApplicationService;
using _2___ConsumidorEmail.CrossCutting;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ApplicationServiceConsumidor>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        cfg.ReceiveEndpoint("enviar-email", e =>
        {
            e.UseMessageRetry(r => r.Interval(2, 100));
            e.ConfigureConsumer<ApplicationServiceConsumidor>(context);
        });
    });
});

builder.Services.AddHostedService<MassTransitHostedService>();

Module.RegisterModules(builder.Services);

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
