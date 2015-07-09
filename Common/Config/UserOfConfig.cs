namespace Common.Config
{
    using System.Windows;

    public class UserOfConfig
    {
        private readonly Config _config;

        public UserOfConfig(Config config)
        {
            _config = config;
        }

        public void Quack()
        {
            MessageBox.Show(_config.Name);
        }
    }
}
