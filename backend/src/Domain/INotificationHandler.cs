namespace Domain
{
    public interface INotificationHandler
    {
        string Messages { get; }

        NotificationHandler AddNotification(string notification);

        bool HasNotification { get; }
    }
}