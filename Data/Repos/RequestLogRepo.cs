namespace RabbitMQTest.Data.Repos
{
    public class RequestLogRepo : Repository<RequestLogs>, IRequestLogRepo
    {
        public RequestLogRepo(BosMessageQueueDbContext dbContext) : base(dbContext)
        {
        }
    }
}
