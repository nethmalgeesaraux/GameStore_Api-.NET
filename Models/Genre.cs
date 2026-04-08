using System;

namespace GameStore.Api.Models;

public class Genre
{

    public int Id { get; set; }

    public required String Name { get; set; }

    public Genre? Gen { get; set; }

    public int GenreId { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
