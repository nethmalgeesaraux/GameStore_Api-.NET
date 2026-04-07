
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetName";
    private static readonly List<GameDto> games = [
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

 public static void MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/game");

        //Get /game
        group.MapGet("/", () => games);


        //Get /game/{id}
        group.MapGet("/{id}", (int id) =>
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
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
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
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
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
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(games => games.Id == id);
            return Results.NoContent();
        });
    }

}
