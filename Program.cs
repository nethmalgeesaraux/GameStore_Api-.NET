using GameStore.Api.Data;
using GameStore.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoredb();

var app = builder.Build();

app. MapGameEndpoints();

app.MigrateDatabase();

app.Run();
