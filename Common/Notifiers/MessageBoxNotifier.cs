namespace Common.Notifiers
{
    using System.Windows;

    public class MessageBoxNotifier : INotifier
    {
        private readonly string _name;

        public MessageBoxNotifier(string name)
        {
            _name = name;
        }

        public void Notify(string message, params object[] args)
        {
            MessageBox.Show(string.Format(message, args), _name);
        }
    }
}
