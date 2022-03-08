using Microsoft.AspNetCore.Mvc;

namespace ContributionService.Controllers;

[ApiController]
[Route("[controller]")]
public class ContributionController : ControllerBase
{
    private readonly ILogger<ContributionController> _logger;

    public ContributionController(ILogger<ContributionController> logger)
    {
        _logger = logger;
    }

    [HttpPost("add")]
    public string Add(ContributionPayload payload)
    {
        return $"Received {payload.Amount} for order {payload.OrderId}";
    }
    
    [HttpGet("balance/{orderId}")]
    public string Balance(string orderId)
    {
        return $"Balance for order {orderId}";
    }
}