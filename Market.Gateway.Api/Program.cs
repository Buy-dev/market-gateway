var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGrpc();
builder.Services.AddGrpcClient<YourGrpcService.YourGrpcServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:5001"); // Replace with your gRPC service address
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<YourGrpcServiceImplementation>();
    endpoints.MapControllers();
});

app.Run();