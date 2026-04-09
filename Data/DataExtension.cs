using System;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtension
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static void AddGameStoredb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");

        // builder.Services.AddScoped<GameStoreContext>();
        
        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: Options => Options.UseSeeding((context, _) =>
            {
                if (!context.Set<GameModel>().Any())
                {
                    context.Set<GameModel>().AddRange(
                        new GameModel
                        {
                            Name = "The Legend of Zelda: Breath of the Wild",
                            GenreId = 1,
                            Price = 59.99m,
                            ReleaseDate = new DateOnly(2017, 3, 3)
                        },
                        new GameModel
                        {
                            Name = "Super Mario Odyssey",
                            GenreId = 2,
                            Price = 49.99m,
                            ReleaseDate = new DateOnly(2017, 10, 27)
                        },
                        new GameModel
                        {
                            Name = "Red Dead Redemption 2",
                            GenreId = 3,
                            Price = 59.99m,
                            ReleaseDate = new DateOnly(2018, 10, 26)
                        }
                    );

                    context.SaveChanges();

                }

            })

            );

    }
}
