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
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumer<GmailConsumer>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
                //cfg.Message<SendGmailCommand>(m => m.SetEntityName("my-exchange-Gmail"));//// تنظیم Exchange پیش‌فرض برای MyMessage

                cfg.Host(new Uri("rabbitmq://localhost:5672"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                //// پیکربندی صف گیرنده
                //cfg.ReceiveEndpoint("my-queue-Gmail", e =>
                //{
                //    e.ConfigureConsumer<GmailConsumer>(context);
                //    e.PrefetchCount = 1; // تنظیم تعداد پیام‌های دریافتی همزمان
                //});

                cfg.ConfigureEndpoints(context);
            });        
        });

        // ضروری برای نسخه‌های جدید
       // services.AddMassTransitHostedService();
        //********************************************************************************************

    })
    .Build();









//****************************************************************************






await host.RunAsync();
