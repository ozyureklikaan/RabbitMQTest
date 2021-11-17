var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    // Command and Event Consumers
    x.AddConsumer<CreateNewRequestCommandConsumer>();

    // Default Port: 5672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        // Receivers
        cfg.ReceiveEndpoint("request-service", e =>
        {
            e.ConfigureConsumer<CreateNewRequestCommandConsumer>(context);
        });
    });
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddMediatR(typeof(CreateNewRequestCommandHandler).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
