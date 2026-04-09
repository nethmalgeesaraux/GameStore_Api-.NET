
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetName";

    public static void MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/game");

        //Get /game
        group.MapGet("/", (GameStoreContext dbContext) =>
            dbContext.Games
                .Select(game => game.ToDto())
                .ToList());


        //Get /game/{id}
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            var game = dbContext.Games.Find(id);
            if (game is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game.ToDto());
        })
            .WithName(GetGameEndpointName);

        //Post /game
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            GameModel game = new ()
            {
                Name = newGame.Name,
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };
            dbContext.Games.Add(game);
            dbContext.SaveChanges();
            
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToDto());
        });

        //Put /game/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.GenreId = updatedGame.GenreId;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        //Delete /game/{id}
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
        {
            var game = dbContext.Games.Find(id);
            if (game is null)
            {
                return Results.NotFound();
            }

            dbContext.Games.Remove(game);
            dbContext.SaveChanges();

            return Results.NoContent();
        });
    }

    private static GameDto ToDto(this GameModel game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate);
    }
}
