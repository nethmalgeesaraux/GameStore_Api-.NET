using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{
    public static void MapGenreEndpoints(this WebApplication app)
    {
        app.MapGet("/genres", (GameStoreContext dbContext) =>
            dbContext.Genres
                .OrderBy(genre => genre.Name)
                .Select(genre => genre.ToDto())
                .ToList());
    }

    private static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(
            genre.Id,
            genre.Name);
    }
}
