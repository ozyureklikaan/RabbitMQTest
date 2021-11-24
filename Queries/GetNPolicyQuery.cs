namespace RabbitMQTest.Queries
{
    public class GetNPolicyQuery : IRequest<IEnumerable<Policy>>
    {
        public int PolicyCount { get; set; }
    }
}
