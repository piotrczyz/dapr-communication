using Microsoft.AspNetCore.Mvc;

namespace PaymentGatewayService.Controllers;

[ApiController]
public class PaymentController : ControllerBase
{
    public const string StoreName = "statestore";
    private readonly HttpClient _httpClient;

    public PaymentController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("capture")]
    public bool Capture()
    {
        return true;
    }
}