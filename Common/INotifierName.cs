namespace Common
{
    public interface INotifierClient
    {
        INotifier Notifier { get; set; }
        string NotifierName { get; set; }
    }
}
