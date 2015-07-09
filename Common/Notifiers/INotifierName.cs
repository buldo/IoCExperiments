namespace Common.Notifiers
{
    public interface INotifierClient
    {
        INotifier Notifier { get; set; }
        string NotifierName { get; set; }
    }
}
