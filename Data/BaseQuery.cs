namespace RabbitMQTest.Data
{
    public abstract class BaseQuery
    {
        protected readonly string ConnectionString;

        protected BaseQuery(IConfiguration configuration)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            ConnectionString = configuration.GetConnectionString("BosQueryConnectionString");
        }
    }
}
