using RabbitMQTest.Data.Repos;

namespace RabbitMQTest.Data;

public class DataAccessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpContextAccessor>().AsImplementedInterfaces();
        #region BosDb
        builder.RegisterType<BosDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();

        // Queries
        builder.RegisterType<PolicyQuery>().AsImplementedInterfaces().InstancePerLifetimeScope();

        // Repositories
        #endregion

        #region BosMessageQueueDb
        builder.RegisterType<BosMessageQueueDbContext>().As<BosMessageQueueDbContext>().InstancePerLifetimeScope();
        builder.RegisterType<AutoMigrateDatabase>().AsSelf().As<IStartable>().SingleInstance();
        
        // Queries

        // Repositories
        builder.RegisterType<RequestLogRepo>().As<IRequestLogRepo>().InstancePerLifetimeScope();
        #endregion
    }
}
