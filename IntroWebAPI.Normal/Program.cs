using IntroWebAPI.Normal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureControllers();
builder.Services.ConfigureSwagger();

// builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

// Para que se mantenga en memoria la "DB"
builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();

builder.Services.AddScoped<INotificationService, NotificationService>();

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