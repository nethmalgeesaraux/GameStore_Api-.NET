using GameStore.Api.Dtos;

const string GetGameEndpointName = "GetName";

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
app.MapGet("/game", () => games);


//Get /game/{id}
app.MapGet("/game/{id}", (int id) =>games.Find(games => games.Id == id))
    .WithName(GetGameEndpointName);

//Post /game
app.MapPost("/game",(CreateGameDto newGame) =>
{
  GameDto game = new (
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.Run();
