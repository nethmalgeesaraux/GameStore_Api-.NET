using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (
        1,
        "The Legend of Zelda: Breath of the Wild",
        "Action-Adventure",
        59.99m,
        new DateOnly(2017, 3, 3)),

    new (
        2,
        "God of War",
        "Action-Adventure",
        49.99m,
        new DateOnly(2018, 4, 20)),

    new (
        3,
        "Red Dead Redemption 2",
        "Action-Adventure",
        59.99m,
        new DateOnly(2018, 10, 26)),

];

//Get /game
app.MapGet("/game", () => "Hello World!");

app.Run();
