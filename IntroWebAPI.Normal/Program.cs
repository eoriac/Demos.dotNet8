using IntroWebAPI.Normal;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureControllers();
builder.Services.ConfigureSwagger();


builder.Services.AddDbContext<WeatherAPIContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DemoDb")));

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

// Para que se mantenga en memoria la "DB"
// builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();

#if DEBUG
builder.Services.AddScoped<INotificationService, NotificationService>();
#else
builder.Services.AddScoped<INotificationService, NotificationService>();
#endif
/*
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
REST - Restful APIs -> HATEOAS
gRPC - 
GraphQL
*/