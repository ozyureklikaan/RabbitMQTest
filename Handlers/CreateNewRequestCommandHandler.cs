namespace RabbitMQTest.Handlers;

public class CreateNewRequestCommandHandler : IRequestHandler<CreateNewRequestCommand, ResponseModel>
{
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public CreateNewRequestCommandHandler(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider ?? throw new ArgumentNullException(nameof(sendEndpointProvider));
    }

    public async Task<ResponseModel> Handle(CreateNewRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new ResponseModel();

        try
        {
            var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:request-service"));

            var requestMessageCommand = new CreateNewRequestCommand()
            {
                Url = request.Url,
                Policy = request.Policy
            };

            await sendEndPoint.Send<CreateNewRequestCommand>(requestMessageCommand);

            Console.WriteLine("RabbitMqTest.Api => Request added to queue.");
        }
        catch (Exception ex)
        {
            response.ErrorMessage = $"Hata = {ex.Message}";
            Console.WriteLine("RabbitMqTest.Api => Request was not added to the queue.");
        }

        return response;
    }
}
