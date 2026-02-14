using GameCatalog.Data;
using GameCatalog.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=games.db"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    if (!context.Games.Any())
    {
        context.Games.AddRange(
            new Game { Title = "The Witcher 3", Developer = "CD Projekt RED", Genre = "RPG", Year = 2015, Rating = 9 },
            new Game { Title = "Elden Ring", Developer = "FromSoftware", Genre = "Action RPG", Year = 2022, Rating = 9 },
            new Game { Title = "Cyberpunk 2077", Developer = "CD Projekt RED", Genre = "RPG", Year = 2020, Rating = 8 },
            new Game { Title = "Hades", Developer = "Supergiant Games", Genre = "Roguelike", Year = 2020, Rating = 9 },
            new Game { Title = "Stardew Valley", Developer = "ConcernedApe", Genre = "Simulation", Year = 2016, Rating = 9 }
        );
        context.SaveChanges();
    }
}

app.Run();
