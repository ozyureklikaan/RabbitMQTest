namespace RabbitMQTest.Consumers;

public class CreateNewRequestCommandConsumer : IConsumer<CreateNewRequestCommand>
{
    private readonly IRequestLogRepo _requestLogRepo;

    public CreateNewRequestCommandConsumer(IRequestLogRepo requestLogRepo)
    {
        _requestLogRepo = requestLogRepo;
    }

    public async Task Consume(ConsumeContext<CreateNewRequestCommand> context)
    {
        Console.WriteLine("RabbitMqTest.Api => Request made.");

        _requestLogRepo.Add(new RequestLogs()
        {
            Url = "test",
            Request = "test",
            Response = "test",
            Description = "test"
        });

        _requestLogRepo.Commit();
    }
}
