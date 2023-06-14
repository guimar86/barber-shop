using Barbershop.Contracts.Events;
using Barbershop.Notification.Config;
using Barbershop.Notification.Consumers;
using Barbershop.Notification.Services;
using MassTransit;
using Microsoft.Extensions.Options;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

//logs

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotification, NotificationService>();
builder.Services.AddScoped<IEmailNotificationProvider, EmailNotificationProvider>();
builder.Services.AddScoped<ISmsNotificationProvider, SmsNotificationProvider>();
builder.Services.AddScoped<IPushNotificationProvider, PushNotificationProvider>();

//logging serilog
builder.Host.UseSerilog((x, y) => { y.WriteTo.Console(); });

//mass transit setup
builder.Services.Configure<MessageBrokerSettings>(builder.Configuration.GetSection("MessageBroker"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);
builder.Services.AddMassTransit(config =>
{
    config.SetKebabCaseEndpointNameFormatter();
    config.AddConsumers(typeof(Program).Assembly);
    config.UsingRabbitMq((context, rabbit) =>
    {
        var settings = context.GetRequiredService<MessageBrokerSettings>();
        rabbit.Host(new Uri(settings.Host), h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });

        rabbit.ReceiveEndpoint("customer-deleted-queue",
            endpoint => { endpoint.ConfigureConsumer<CustomerDeletionConsumer>(context); });
        rabbit.ReceiveEndpoint("customer-created-queue",
            endpoint => { endpoint.ConfigureConsumer<CustomerCreationConsumer>(context); });
        rabbit.ReceiveEndpoint("appointment-created-queue",
            endpoint => { endpoint.ConfigureConsumer<AppointmentCreatedConsumer>(context); });
        rabbit.ReceiveEndpoint(queueName: "appointment-deleted-queue",
            endpoint => { endpoint.ConfigureConsumer<AppointmentDeletedConsumer>(context); });
        rabbit.ReceiveEndpoint(queueName: "appointment-updated-queue",
            endpoint => { endpoint.ConfigureConsumer<AppointmentUpdatedConsumer>(context); });
    });
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

app.MapControllers();

app.Run();