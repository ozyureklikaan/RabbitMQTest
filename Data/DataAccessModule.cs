using RabbitMQTest.Data.Repos;

namespace RabbitMQTest.Data;

public class DataAccessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpContextAccessor>().AsImplementedInterfaces();
        builder.RegisterType<BosDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();

        // Queries
        builder.RegisterType<PolicyQuery>().AsImplementedInterfaces().InstancePerLifetimeScope();

        // Repositories

    }
}
