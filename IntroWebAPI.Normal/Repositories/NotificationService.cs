namespace IntroWebAPI.Normal;

public class NotificationService : INotificationService
{
    private readonly IWeatherRepository weatherRepository;

    public NotificationService(IWeatherRepository weatherRepository)
    {
        this.weatherRepository = weatherRepository;
    }

    public void Notify(string message){

        System.Console.WriteLine(message);

        var collection = this.weatherRepository.GetWeatherForecasts();
        foreach (var item in collection)
        {
            System.Console.WriteLine(item.TemperatureC);
        }
    }
}

public interface INotificationService
{
    void Notify(string message);
}