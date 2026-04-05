var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Get /game
app.MapGet("/game", () => "Hello World!");

app.Run();
