var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var daprPort = "3500";
builder.Services.AddHttpClient("OrderService", c =>
{
    c.BaseAddress = new Uri($"http://localhost:{daprPort}/v1.0");
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseCloudEvents();

app.UseAuthorization();

app.MapControllers();

app.Run("http://*:5280");