namespace RabbitMQTest.Models;

public class ResponseModel
{
    private string errorMessage { get; set; }
    private bool errorOccurred { get; set; }

    public int StatusCode { get; set; }
    public string ErrorMessage
    {
        get => errorMessage;
        set
        {
            errorMessage = value;
            errorOccurred = !string.IsNullOrEmpty(errorMessage);

        }
    }
    public bool ErrorOccurred { get; }
}