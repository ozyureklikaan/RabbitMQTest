using RabbitMQTest.Domain.Policy;
using System.Data.SqlClient;

namespace RabbitMQTest.Data.Repos
{
    public class PolicyQuery : BaseQuery, IPolicyQuery
    {
        public PolicyQuery(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Policy>> GetNPolicyAsync(int policyCount)
        {
            await using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return await connection.QueryAsync<Policy>(@"
                            select top @top ROW_ID, POLICY_SERIAL_NO, GROSS_PREMIUM
                            from dbo.T_POLICY_MASTER",
                            new { top = policyCount });
        }
    }
}
