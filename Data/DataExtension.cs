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
        var connString = "Data Source= GameStore.db";

        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: Options => Options.UseSeeding((context, _) =>
            {
                if (!context.Set<GameModel>().Any())
                {
                    context.Set<GameModel>().AddRange(
                        new GameModel { Name = "The Legend of Zelda: Breath of the Wild" },
                        new GameModel { Name = "Super Mario Odyssey" },
                        new GameModel { Name = "Red Dead Redemption 2" }
                    );

                    context.SaveChanges();

                }

            })

            );

    }
}
