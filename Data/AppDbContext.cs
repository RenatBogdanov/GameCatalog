using GameCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameCatalog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
}