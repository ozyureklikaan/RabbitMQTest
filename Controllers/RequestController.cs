namespace RabbitMQTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly BosMessageQueueDbContext _bosMessageQueueDbContext;
    private readonly IRequestLogRepo _requestLogRepo;

    public RequestController(IMediator mediator, IRequestLogRepo requestLogRepo)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _requestLogRepo = requestLogRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _requestLogRepo.Add(new RequestLogs()
        {
            Url = "test",
            Request = "test",
            Response = "test",
            Description = "test"
        });

        _requestLogRepo.Commit();

        return Ok();
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
