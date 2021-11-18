var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    // Command and Event Consumers
    x.AddConsumer<CreateNewRequestCommandConsumer>();

    // Default Port: 5672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(configuration["RabbitMQUrl"], "/", host =>
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

builder.Services.AddDbContext<BosMessageQueueDbContext>(opt =>
{
    opt.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddMediatR(typeof(CreateNewRequestCommandHandler).Assembly);

var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Localization
var supportedCultures = new[] { new CultureInfo("tr-TR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
    // Formatting numbers, dates, etc.
    SupportedCultures = supportedCultures,
    // UI strings that we have localized.
    SupportedUICultures = supportedCultures
});

// Migration
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var orderDbContext = serviceProvider.GetRequiredService<BosMessageQueueDbContext>();

    orderDbContext.Database.Migrate();
}

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
