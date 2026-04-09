using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using GameStore.Api.Models;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString =  "Data Source= GameStore.db";

builder.Services.AddSqlite<GameStoreContext>(
    connString,
    optionsAction : Options => Options.UseSeeding((context, _) =>
    {
        if(!context.Set<GameModel>().Any())
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

var app = builder.Build();

app. MapGameEndpoints();

app.MigrateDatabase();

app.Run();
