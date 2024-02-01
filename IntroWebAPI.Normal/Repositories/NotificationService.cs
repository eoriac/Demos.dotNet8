namespace IntroWebAPI.Normal;

public class NotificationService : INotificationService
{
    public NotificationService()
    {
    }

    public void Notify(string message){

        System.Console.WriteLine(message);
    }
}
