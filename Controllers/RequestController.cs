namespace RabbitMQTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly BosMessageQueueDbContext _bosMessageQueueDbContext;

    public RequestController(IMediator mediator, BosMessageQueueDbContext bosMessageQueueDbContext)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _bosMessageQueueDbContext = bosMessageQueueDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var r = _bosMessageQueueDbContext.RequestLogs.FirstOrDefault();

        return Ok(r);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest(CreateNewRequestCommand command)
    {
        var response = await _mediator.Send(command);

        if (!response.ErrorOccurred)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }
}
