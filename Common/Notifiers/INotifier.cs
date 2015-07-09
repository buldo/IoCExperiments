namespace Common.Notifiers
{
    public interface INotifier
    {
        void Notify(string message, params object[] args);
    }
}
