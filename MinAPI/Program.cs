var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();
var app = builder.Build();

app.MapGet("/", () => "Welcome to Notes API!");

await app.RunAsync();