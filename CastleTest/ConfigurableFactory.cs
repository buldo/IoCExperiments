namespace CastleTest
{
    using Castle.MicroKernel;
    using Common.Config;

    class ConfigurableFactory : IConfigurableFactory
    {
        private readonly IKernel _kernel;

        public ConfigurableFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public UserOfConfig Create(Config config)
        {
            return _kernel.Resolve<UserOfConfig>(new {config});
        }
    }
}
