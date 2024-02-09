using Microsoft.EntityFrameworkCore;

namespace IntroWebAPI.Normal;

public class WeatherAPIContext : DbContext
{

    public WeatherAPIContext(DbContextOptions<WeatherAPIContext> options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var wf1 = 
            new WeatherForecast
                {
                    Id = Guid.Parse("2e648dae-7e7d-4289-a5d4-4dedca70ca8d"),
                    Location = "Madrid",
                    Summary = "Freezing",
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                };
        
        var wf2 = 
            new WeatherForecast
            {
                Id = Guid.Parse("f011e50e-98eb-4f8c-90c8-cd2dfbd5b27a"),
                Location = "Valencia",
                Summary = "Chilly",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                TemperatureC = Random.Shared.Next(-20, 55),
            };


        modelBuilder.Entity<WeatherForecast>()
            .HasData(wf1, wf2);
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;

    public DbSet<City> Cities { get; set; } = null!;
}
