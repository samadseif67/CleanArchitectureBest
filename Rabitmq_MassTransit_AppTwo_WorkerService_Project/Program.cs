using MassTransit;
using Rabitmq_MassTransit_AppTwo_WorkerService_Project;
using Rabitmq_MassTransit_AppTwo_WorkerService_Project.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
       // services.AddHostedService<Worker>();

        //***********************************************************************************************
        services.AddTransient<IGmailSenderService, GmailSenderService>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<GmailConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ReceiveEndpoint("Gmail-Queue", e =>
                {
                    e.ConfigureConsumer<GmailConsumer>(context);
                });
            });        
        });
      //********************************************************************************************

    })
    .Build();









//****************************************************************************






await host.RunAsync();
