using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using GameStore.Api.Models;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();


var app = builder.Build();

app. MapGameEndpoints();

app.MigrateDatabase();

app.Run();
