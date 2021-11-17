namespace RabbitMQTest.Models.DataModels;

public class RequestLogs
{
    public int RowId { get; set; }
    public string Url { get; set; }
    public string Request { get; set; }
    public string Response { get; set; }
    public DateTime LogDate { get; set; }
    public string Description { get; set; }
}
