namespace Common.Config
{
    public interface IConfigurableFactory
    {
        UserOfConfig Create(Config config);
    }
}
