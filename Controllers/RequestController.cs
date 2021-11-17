namespace RabbitMQTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public RequestController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
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
