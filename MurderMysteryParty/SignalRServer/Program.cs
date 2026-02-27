using SignalRServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var clientUrl = builder.Configuration["ClientUrl"] ?? "http://localhost:5059";
        policy.WithOrigins(clientUrl, "http://localhost:5000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors();

app.MapHub<RoundHub>("/roundhub");
app.MapGet("/", () => "SignalR round hub is running.");

app.Run();
