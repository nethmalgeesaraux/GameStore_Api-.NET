using System;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
    : DbContext(options)
{

    public DbSet<GameModel> Games => Set<GameModel>();

    public DbSet<Genre> Genres => Set<Genre>();
}
