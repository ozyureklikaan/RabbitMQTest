namespace RabbitMQTest.Consumers;

public class CreateNewRequestCommandConsumer : IConsumer<CreateNewRequestCommand>
{
    public async Task Consume(ConsumeContext<CreateNewRequestCommand> context)
    {
        Console.WriteLine("RabbitMqTest.Api => Request made.");
    }
}
