namespace RabbitMQTest.Context
{
    public class AutoMigrateDatabase : IStartable
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoggerFactory _loggerFactory;

        public AutoMigrateDatabase(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _loggerFactory = loggerFactory;
        }

        public void Start()
        {
            using (var dbContext = new BosMessageQueueDbContext(_configuration, _httpContextAccessor, _loggerFactory))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
