namespace RabbitMQTest.Domain.Policy
{
    public interface IPolicyQuery
    {
        Task<IEnumerable<Models.Policy>> GetNPolicyAsync(int policyCount);
    }
}
