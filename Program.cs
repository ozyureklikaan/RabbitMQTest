var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Get Configuration
IConfiguration configuration = builder.Configuration;
#endregion

#region Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new MediatorModule());
    containerBuilder.RegisterModule(new DataAccessModule());
});
#endregion

#region MassTransit
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

builder.Services.AddMassTransitHostedService();
#endregion

#region DbContext
builder.Services.AddDbContext<BosMessageQueueDbContext>(opt =>
{
    opt.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
});

//builder.Services.AddDbContext<BosDbContext>(options =>
//{
//    options.UseSqlServer(configuration.GetConnectionString("BosDb"));
//});
#endregion

#region Culture
var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Localization
var supportedCultures = new[] { new CultureInfo("tr-TR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
    // Formatting numbers, dates, etc.
    SupportedCultures = supportedCultures,
    // UI strings that we have localized.
    SupportedUICultures = supportedCultures
});
#endregion

#region Migration
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var orderDbContext = serviceProvider.GetRequiredService<BosMessageQueueDbContext>();

    orderDbContext.Database.Migrate();
}
#endregion

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
