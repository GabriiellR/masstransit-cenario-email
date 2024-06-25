using _2_ConsumidorEmail.ApplicationService;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("enviar-email", e =>
    {
        e.Consumer<ApplicationServiceChamado>();
        e.PrefetchCount = 10;
    });

});
busControl.Start();

Console.WriteLine("Waiting for messages...");

while (true) ;
