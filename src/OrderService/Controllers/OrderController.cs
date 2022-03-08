using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public OrderController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient.CreateClient("OrderService");
    }
    
    [HttpGet("Health")]
    public ActionResult<object> OkResult()
    {
        return new { Status = DateTime.Today};
    }

    [HttpPost("order/deposit")]
    public async Task<string> Deposit(Order order)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        var response = await _httpClient.PostAsJsonAsync("v1.0/invoke/PaymentGatewayService/method/Capture", new
        {
            id = order.OrderId,
            amount = order.Amount
        });

        var success = await response.Content.ReadFromJsonAsync<bool>(new JsonSerializerOptions());

        if (success)
        {
            var added = await _httpClient.PostAsJsonAsync("v1.0/invoke/ContributionService/method/contribution/add", 
                new {orderId = order.OrderId, amount = order.Amount});

            var returnMessage = await added.Content.ReadAsStringAsync();
            
            stopWatch.Stop();
            return $"{returnMessage}. Finished in {stopWatch.ElapsedMilliseconds} milliseconds.";
        }

        return string.Empty;
    }
    
    [HttpGet("order/balance/{orderId}")]
    public async Task<string> GetBalance(string orderId)
    {
        var response = await _httpClient.GetAsync($"v1.0/invoke/ContributionService/method/contribution/balance/{orderId}");
        return await response.Content.ReadAsStringAsync();
    }
}