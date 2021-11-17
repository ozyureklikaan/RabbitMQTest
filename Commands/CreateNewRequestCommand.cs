namespace RabbitMQTest.Commands;

public class CreateNewRequestCommand : IRequest<ResponseModel>
{
    public string Url { get; set; }
    public object Policy { get; set; }
}