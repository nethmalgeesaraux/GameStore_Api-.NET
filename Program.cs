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
app.MapGet("/game/{id}", (int id) =>
{
    var game = games.FirstOrDefault(games => games.Id == id);
    if (game is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(game);
})
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

//Put /game/{id}
app.MapPut("/game/{id}", (int id, UpdateGameDto updatedGame) =>
{
  var index = games.FindIndex(games => games.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

  games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

//Delete /game/{id}
app.MapDelete("/game/{id}", (int id) =>
{
   games.RemoveAll(games => games.Id == id);
   return Results.NoContent();
});

app.Run();
