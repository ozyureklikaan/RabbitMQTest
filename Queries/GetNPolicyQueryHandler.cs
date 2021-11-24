namespace RabbitMQTest.Queries
{
    public class GetNPolicyQueryHandler : IRequestHandler<GetNPolicyQuery, IEnumerable<Policy>>
    {
        private readonly IPolicyQuery _policyQuery;

        public GetNPolicyQueryHandler(IPolicyQuery policyQuery)
        {
            _policyQuery = policyQuery;
        }

        public async Task<IEnumerable<Policy>> Handle(GetNPolicyQuery request, CancellationToken cancellationToken)
        {
            var policies = await _policyQuery.GetNPolicyAsync(request.PolicyCount);

            return policies;
        }
    }
}
